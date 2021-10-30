using luval.vision.core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luval.vision.sink
{
    public partial class MainForm : Form
    {

        private string _fileName;
        private ImageManager _imageManager;
        private OcrResult _result;
        private Image _resultImg;
        private ProcessResult _processResult;
        private FormResult _formResult;

        public MainForm()
        {
            InitializeComponent();
        }

        public PictureBox PictureBox { get { return pictureBox; } }
        public string ResultText
        {
            get { return resultText.Text; }
            set { resultText.Text = value; }
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            _fileName = null;
            var dialog = new OpenFileDialog()
            {
                Title = "Open Image",
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.PDF;*.celeris)|*.BMP;*.JPG;*.GIF;*.PNG;*.PDF;*.celeris|All files (*.*)|*.*",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            _fileName = dialog.FileName;
            DoLoadImage(_fileName);
        }

        private void DoLoadImage(string fileName)
        {
            var formResult = CheckForCelerisFile(fileName);
            if(formResult == null)
                DoLoadImage(fileName, File.ReadAllBytes(fileName));
            else
            {
                _formResult = formResult;
                DoLoadImage(formResult.FileName, formResult.FileData);
            }
        }

        private void DoLoadImage(string fileName, byte[] data)
        {
            if (PictureBox.Image != null) PictureBox.Image.Dispose();
            PictureBox.Image = null;
            var img = default(Image);
            using (var stream = new MemoryStream(data))
            {
                img = Image.FromStream(stream);
                stream.Close();
            }
            _imageManager = new ImageManager(img);
            _result = null;
            PictureBox.Image = img;
            PictureBox.Refresh();
        }

        private FormResult CheckForCelerisFile(string fileName)
        {
            if (!fileName.ToLowerInvariant().EndsWith(".celeris")) return null;
            _formResult = JsonConvert.DeserializeObject<FormResult>(File.ReadAllText(fileName));
            return _formResult;
        }


        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_fileName))
            {
                MessageBox.Show("Please load an image for processing", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            processBtn.Enabled = false;
            DoProcess();
            MessageBox.Show("Process completed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            processBtn.Enabled = true;
        }

        private OcrProvider GetProvider(bool ms)
        {
            return !ms ? new OcrProvider(new GoogleOcrEngine(), new GoogleVisionLoader()) : new OcrProvider(new MicrosoftOcrEngine(), new MicrosoftVisionLoader());
        }



        private void btnDemo_Click(object sender, EventArgs e)
        {
            DoLoadImage(@"Demo/sample-receipt.jpg");
            var response = File.ReadAllText(@"Demo/sample-response.json");
            var ocrResult = JsonConvert.DeserializeObject<OcrResult>(response);
            //DoProcess(ocrResult);

        }

        private void DoProcess()
        {
            var jsonData = File.ReadAllText("attribute-mapping.json");
            var options = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData);
            var provider = new DocumentProcesor(GetProvider(false), new NlpProvider(new GoogleNlpEngine(), new GoogleNlpLoader()));
            var result = default(ProcessResult);
            result = _formResult == null ? provider.DoProcess(_fileName, options) : 
                provider.DoProcess(_formResult.FileData,_formResult.FileName, options, _formResult.Result.OcrResult, _formResult.Result.NlpResult);
            _result = result.OcrResult;
            _processResult = result;
            LoadVisionTree(result.OcrResult);
            LoadText(result.OcrResult);
            _resultImg = _imageManager.ProcessParseResult(result.TextResults);
            PictureBox.Image = _resultImg;
            listResult.Items.Clear();
            foreach (var item in result.TextResults)
            {
                var listItem = new ListViewItem(new string[] { item.Map.AttributeName, item.Value });
                listResult.Items.Add(listItem);
            }
        }

        private void LoadText(OcrResult ocrResult)
        {
            resultText.Clear();
            var sb = new StringBuilder();
            foreach (var line in ocrResult.Lines)
            {
                sb.AppendLine(line.Text);
            }
            resultText.Text = sb.ToString();
        }

        private void LoadVisionTree(OcrResult ocrResult)
        {
            var root = new TreeNode("JSON Result");
            treeJsonVision.Nodes.Clear();
            treeJsonVision.Nodes.Add(root);
            foreach (var region in ocrResult.Regions)
            {
                var regionNode = new TreeNode()
                {
                    Text = string.Format("Region: {0}", region.Code)
                };
                regionNode.Nodes.Add(region.Location.ToString());
                foreach (var line in region.Lines)
                {
                    var lineNode = new TreeNode()
                    {
                        Text = string.Format("Line: {0}", line.Code)
                    };
                    var wordNodeRoot = new TreeNode("Words");
                    lineNode.Nodes.Add(line.Location.ToString());
                    lineNode.Nodes.Add(line.Text);
                    lineNode.Nodes.Add(wordNodeRoot);
                    regionNode.Nodes.Add(lineNode);
                    foreach (var word in line.Words)
                    {
                        var wordNode = new TreeNode(word.Text);
                        wordNode.Nodes.Add(word.Location.ToString());
                        wordNode.Nodes.Add(word.DataType.ToString());
                        wordNodeRoot.Nodes.Add(wordNode);
                    }
                }
                root.Nodes.Add(regionNode);
            }
        }

        private List<MappingResult> GetData(OcrResult result)
        {
            var jsonData = File.ReadAllText("attribute-mapping.json");
            var options = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData);
            var navigator = new Navigator(result.Info, result.Lines, options);
            return navigator.ExtractAttributes();
        }

        private void chkOcrResult_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcrResult.Checked && _result != null)
            {
                PictureBox.Image = _imageManager.ProcessOcrResult(_result);
            }
            else if (_resultImg != null)
            {
                PictureBox.Image = _resultImg;
            }
        }

        private void mnuSaveResult_Click(object sender, EventArgs e)
        {
            if (_processResult == null)
            {
                MessageBox.Show("Please process a document first", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var dlg = new SaveFileDialog()
            {
                DefaultExt = "celeris",
                AddExtension = true,
                Filter = "Celeris Files(*.celeris)|*.celeris",
                RestoreDirectory = true,
                Title = "Save Results",
                OverwritePrompt = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            DoSaveResult(dlg.FileName);
        }

        private void DoSaveResult(string resultFileName)
        {
            var data = new FormResult()
            {
                FileName = _fileName,
                FileData = File.ReadAllBytes(_fileName),
                Result = _processResult
            };
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            using (var stream = new StreamWriter(resultFileName, false))
            {
                stream.Write(json);
                stream.Close();
            }
            MessageBox.Show("Result has been saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuTextCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(resultText.SelectedText);
        }

        private void mnuSelectAllTxt_Click(object sender, EventArgs e)
        {
            resultText.SelectAll();
        }
    }
}
