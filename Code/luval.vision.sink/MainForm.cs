using luval.vision.core;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

        private string _mappingFile;
        private string _fileName;
        private ImageManager _imageManager;
        private OcrResult _result;
        private Image _resultImg;
        private ProcessResult _processResult;
        private FormResult _formResult;
        private RelativeArea _formRelativeArea;

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

        private void OpenFile()
        {
            var dialog = new OpenFileDialog()
            {
                Title = "Open Image",
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.PDF;*.celeris)|*.BMP;*.JPG;*.GIF;*.PNG;*.PDF;*.celeris|All files (*.*)|*.*",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            _fileName = dialog.FileName;
            _result = null;
            _formResult = null;
            DoLoadImage(_fileName);
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void DoLoadImage(string fileName)
        {
            var formResult = CheckForCelerisFile(fileName);
            if (formResult == null)
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

        private void LoadConfiguration()
        {
            var dlg = new OpenFileDialog()
            {
                Title = "Load configuration file",
                Filter = "Json Files (*.json)|*.json",
                Multiselect = false,
                RestoreDirectory = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            _mappingFile = dlg.FileName;
            if (!File.Exists(_mappingFile))
            {
                MessageBox.Show("Invalid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<AttributeMapping> GetMapping()
        {
            if (string.IsNullOrWhiteSpace(_mappingFile)) _mappingFile = "attribute-mapping.json";
            var jsonData = File.ReadAllText(_mappingFile);
            var options = new List<AttributeMapping>();
            try
            {
                options = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("File {0} is not valid: {1}", _mappingFile, ex), "Error");
                MessageBox.Show("Invalid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return options;
        }

        private void DoOCR()
        {
            if (string.IsNullOrWhiteSpace(_fileName)) return;
            var ocrProvider = GetProvider(false);
            if (_result == null)
                _result = ocrProvider.DoOcr(_fileName);
        }

        private void DoProcess()
        {
            var options = GetMapping();
            var provider = new DocumentProcesor(GetProvider(false));
            var result = default(ProcessResult);
            DoOCR();
            result = _formResult == null ? provider.DoProcess(File.ReadAllBytes(_fileName), _fileName, options, _result) :
                provider.DoProcess(_formResult.FileData, _formResult.FileName, options, _formResult.Result.OcrResult);
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
                    regionNode.Nodes.Add(lineNode);
                    foreach (var word in line.Words)
                    {
                        var wordNode = new TreeNode(word.Text);
                        wordNode.Nodes.Add(word.Location.ToString());
                        wordNode.Nodes.Add(word.DataType.ToString());
                        wordNodeRoot.Nodes.Add(wordNode);
                    }
                    lineNode.Nodes.Add(wordNodeRoot);
                }
                root.Nodes.Add(regionNode);
            }
        }

        private void ShowOCRBoxes()
        {
            if (_result != null)
            {
                PictureBox.Image = _imageManager.ProcessOcrResult(_result);
            }
        }

        private void chkOcrResult_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOcrResult.Checked)
            {
                ShowOCRBoxes();
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

        private void mnuLoadConfiguration_Click(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_result == null) return;
            var words = _result.Words.Where(i => i.Location.Y >= e.Y && i.Location.X >= e.X).OrderBy(o => o.Location.Y).ThenBy(o => o.Location.X).ToList();
            var word = words.FirstOrDefault();
            if (word == null) return;
            MessageBox.Show(word.Text, "OCR Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuRunOCR_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_fileName)) OpenFile();
            DoOCR();
            ShowOCRBoxes();
            if (_result != null)
            {
                LoadVisionTree(_result);
                LoadText(_result);
            }
        }

        private void ExtractFormValues()
        {
            DoOCR();
            var options = GetMapping();
            var docProvider = new DocumentProcesor(GetProvider(false));
            var result = docProvider.DoProcess(File.ReadAllBytes(_fileName), _fileName, options, _result);
            _processResult = result;
            _resultImg = _imageManager.ProcessParseResult(result.TextResults);
            PictureBox.Image = _resultImg;
            listResult.Items.Clear();
            foreach (var item in result.TextResults)
            {
                var listItem = new ListViewItem(new string[] { item.Map.AttributeName, item.Value });
                listResult.Items.Add(listItem);
            }
        }

        private void extractFormValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_mappingFile)) LoadConfiguration();
            if (string.IsNullOrWhiteSpace(_fileName)) OpenFile();
            ExtractFormValues();

        }

        private void mnuExportToExcel_Click(object sender, EventArgs e)
        {
            if (_processResult == null) return;
            var dlg = new SaveFileDialog()
            {
                Title = "Save Results to Excel",
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                RestoreDirectory = true
            };
            if (dlg.ShowDialog() == DialogResult.Cancel) return;
            var file = new FileInfo(dlg.FileName);
            using (var package = new ExcelPackage(file))
            {
                var sheet = package.Workbook.Worksheets.Add("Results");
                sheet.Cells[1, 1].Value = "Field";
                sheet.Cells[1, 2].Value = "Value";
                var row = 2;
                foreach (var result in _processResult.TextResults)
                {
                    sheet.Cells[row, 1].Value = result.Map.AttributeName;
                    sheet.Cells[row, 2].Value = result.Value;
                    row++;
                }
                // Save to file
                package.Save();
            }
        }

        private void mnuDrawArea_Click(object sender, EventArgs e)
        {
            if (_formRelativeArea == null) _formRelativeArea = new RelativeArea();
            if (_imageManager == null) return;
            if (_result == null) return;

            var region = _result.Regions.FirstOrDefault();
            _formRelativeArea.WorkingArea = new OcrLocation() { X = 0, Width = _imageManager.Source.Width, Y = 0, Height = _imageManager.Source.Height };
            if (_formRelativeArea.ShowDialog() == DialogResult.Cancel) return;


            var loc = OcrRelativeLocation.FromRelative(_result.Info.ToLocation(), _formRelativeArea.X, _formRelativeArea.XBound, _formRelativeArea.Y, _formRelativeArea.YBound);
            PictureBox.Image = _imageManager.DrawRegion(region, loc);
        }
    }
}
