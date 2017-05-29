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
        private Image _originalImg;
        private ProcessResult _processResult;
        private List<AttributeMapping> _profiles;

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
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG; *.TIF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIF|All files (*.*)|*.*",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            _fileName = dialog.FileName;
            DoLoadImage(_fileName);
        }

        private void DoLoadImage(string fileName)
        {
            if (PictureBox.Image != null) PictureBox.Image.Dispose();
            PictureBox.Image = null;
            var data = File.ReadAllBytes(fileName);
            var img = default(Image);
            using (var stream = new MemoryStream(Pdf2Img.CheckForPdfAndConvert(data, fileName, "")))
            {
                img = Image.FromStream(stream);
                stream.Close();
            }
            _imageManager = new ImageManager(img);
            _result = null;
            PictureBox.Image = img;
            PictureBox.Refresh();
            _originalImg = img;
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

        public OcrProvider GetProvider(bool ms)
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
            var options = GetProfile();
            var provider = new DocumentProcesor(GetProvider(false), new NlpProvider(new GoogleNlpEngine(), new GoogleNlpLoader()));
            var result = provider.DoProcess(_fileName, options, "");
            var tuple = new Tuple<OcrResult, List<AttributeMapping>>(result.OcrResult, options);
            _result = result.OcrResult;
            _processResult = result;
            LoadVisionTree(result.OcrResult);
            LoadText(result.OcrResult);
            ShowParseResult();
            listResult.Tag = null;
            listResult.Items.Clear();
            listResult.Tag = new Tuple<ProcessResult, List<AttributeMapping>>(result, options);
            foreach (var map in options)
            {
                var value = default(string);
                var item = result.TextResults.FirstOrDefault(i => i.Map.AttributeName == map.AttributeName);
                if (item != null) value = item.Value;
                var listItem = new ListViewItem(new string[] { map.AttributeName, value });
                if (!string.IsNullOrWhiteSpace(value))
                    listItem.Tag = item;
                listResult.Items.Add(listItem);
            }
            rdResult.Checked = true;
            grpResults.Enabled = true;
            btnClear.Enabled = true;
            ListViewHelper.Prepare(listResult);
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



        private void LoadImg(Image img)
        {
            PictureBox.Image = img;
            PictureBox.Refresh();
        }

        private void DoClear()
        {
            if (_originalImg == null) return;
            LoadImg(_originalImg);
        }

        private void ShowParseResult()
        {
            if (_processResult == null) return;
            DoClear();
            LoadImg(_imageManager.ProcessParseResult(_processResult.TextResults));

        }

        private void ShowVisionResult()
        {
            if (_result == null) return;
            DoClear();
            LoadImg(_imageManager.ProcessOcrResult(_result));

        }

        private void ShowWords()
        {
            if (_result == null || _originalImg == null) return;
            LoadImg(ImageManager.ProcessElements(PictureBox.Image, _result.Words.Where(i => i.DataType == DataType.Word).ToList(), Color.LightGray));
        }

        private void ShowDates()
        {
            if (_result == null || _originalImg == null) return;
            LoadImg(ImageManager.ProcessElements(PictureBox.Image, _result.Lines.Where(i => i.HasDate).ToList(), Color.Red));
        }

        private void ShowNumbers()
        {
            if (_result == null || _originalImg == null) return;
            LoadImg(ImageManager.ProcessElements(PictureBox.Image, _result.Words.Where(i => i.DataType == DataType.Number).ToList(), Color.Blue));
        }

        private void ShowAmounts()
        {
            if (_result == null || _originalImg == null) return;
            LoadImg(ImageManager.ProcessElements(PictureBox.Image, _result.Lines.Where(i => i.HasAmount).ToList(), Color.Black));
        }

        private void ShowCodes()
        {
            if (_result == null || _originalImg == null) return;
            LoadImg(ImageManager.ProcessElements(PictureBox.Image, _result.Lines.Where(i => i.HasCode).ToList(), Color.Orange));
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            DoClear();
        }

        private void rdResult_Click(object sender, EventArgs e)
        {
            ShowParseResult();
        }

        private void rdVision_Click(object sender, EventArgs e)
        {
            ShowVisionResult();
        }

        private void rdAmounts_Click(object sender, EventArgs e)
        {
            ShowAmounts();
        }

        private void rdDates_Click(object sender, EventArgs e)
        {
            ShowDates();
        }

        private void rdCodes_Click(object sender, EventArgs e)
        {
            ShowCodes();
        }

        private void rdWords_Click(object sender, EventArgs e)
        {
            ShowWords();

        }

        private void rdNumbers_Click(object sender, EventArgs e)
        {
            ShowNumbers();
        }

        private void mnuSaveImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_fileName)) return;
            var file = new FileInfo(_fileName);
            var filter = "Image File|*" + file.Extension;
            var saveDlg = new SaveFileDialog()
            {
                Filter = filter,
                Title = "Save Output Image",
                RestoreDirectory = true
            };
            if (saveDlg.ShowDialog() == DialogResult.Cancel) return;
            PictureBox.Image.Save(saveDlg.FileName);
        }

        private void listResult_DoubleClick(object sender, EventArgs e)
        {
            if (listResult.SelectedItems.Count <= 0) return;
            var item = listResult.SelectedItems[0];
            var mapping = default(MappingResult);
            if (item.Tag != null) mapping = (MappingResult)item.Tag;
            var frm = new ShowMap() { OcrResult = _processResult.OcrResult, MappingResult = mapping };
            frm.ShowDialog();
        }

        private void mnuLoadProfile_Click(object sender, EventArgs e)
        {
            var openDlg = new OpenFileDialog()
            {
                Filter = "json files *.json|*.json",
                Title = "Load Profile",
                RestoreDirectory = true,
            };
            if (openDlg.ShowDialog() == DialogResult.Cancel) return;
            try
            {
                _profiles = JsonConvert.DeserializeObject<List<AttributeMapping>>(File.ReadAllText(openDlg.FileName));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid profile file", "Error Loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _profiles = null;
                return;
            }
            lblProfile.Text = "Profile: " + new FileInfo(openDlg.FileName).Name;
        }

        private List<AttributeMapping> GetProfile()
        {
            if(_profiles == null)
            {
                var jsonData = File.ReadAllText("attribute-mapping.json");
                _profiles = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData);
                lblProfile.Text = "Profile: Default Profile";
            }
            return _profiles;
        }
    }
}
