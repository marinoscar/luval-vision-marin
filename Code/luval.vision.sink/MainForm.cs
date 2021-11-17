using luval.vision.core;
using luval.vision.google;
using luval.vision.microsoft;
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

namespace luval.vision.app
{
    public partial class MainForm : BaseForm
    {

        private ImageManager _imageManager;


        public MainForm()
        {
            InitializeComponent();
        }

        public PictureBox PictureBox { get { return pictureBox; } }
        public FileInfo PictureFile { get; set; }
        public OcrResult OcrResult { get; set; }

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
            PictureFile = new FileInfo(dialog.FileName);
            OcrResult = null;
            DoLoadImage(PictureFile.FullName);
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void DoLoadImage(string fileName)
        {
            DoLoadImage(fileName, File.ReadAllBytes(fileName));
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
            OcrResult = null;
            PictureBox.Image = img;
            PictureBox.Refresh();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            if (PictureFile == null || !PictureFile.Exists)
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

        private void DoOCR()
        {
            if (PictureFile == null || !PictureFile.Exists) OpenFile();
            var ocrProvider = GetProvider(false);
            if (OcrResult == null)
                OcrResult = ocrProvider.DoOcr(PictureFile.FullName);
        }

        private void DoProcess()
        {
        }

        private void LoadText(OcrResult ocrResult)
        {
            resultText.Clear();
            var sb = new StringBuilder();
            var lineProvider = new MidLineOcrLineResolver();
            var lines = lineProvider.GetLines(ocrResult.Words, new Dictionary<string, string>());
            foreach (var line in lines)
            {
                sb.AppendLine(line.Text);
            }
            resultText.Text = sb.ToString();
        }

        private void LoadVisionTree(OcrResult ocrResult)
        {
            //var root = new TreeNode("JSON Result");
            //treeJsonVision.Nodes.Clear();
            //treeJsonVision.Nodes.Add(root);
            //foreach (var region in ocrResult.Regions)
            //{
            //    var regionNode = new TreeNode()
            //    {
            //        Text = string.Format("Region: {0}", region.Code)
            //    };
            //    regionNode.Nodes.Add(region.Location.ToString());
            //    foreach (var line in region.Lines)
            //    {
            //        var lineNode = new TreeNode()
            //        {
            //            Text = string.Format("Line: {0}", line.Code)
            //        };
            //        var wordNodeRoot = new TreeNode("Words");
            //        lineNode.Nodes.Add(line.Location.ToString());
            //        lineNode.Nodes.Add(line.Text);
            //        regionNode.Nodes.Add(lineNode);
            //        foreach (var word in line.Words)
            //        {
            //            var wordNode = new TreeNode(word.Text);
            //            wordNode.Nodes.Add(word.Location.ToString());
            //            wordNode.Nodes.Add(word.DataType.ToString());
            //            wordNodeRoot.Nodes.Add(wordNode);
            //        }
            //        lineNode.Nodes.Add(wordNodeRoot);
            //    }
            //    root.Nodes.Add(regionNode);
            //}
        }

        private void ShowOCRBoxes()
        {
            if (OcrResult != null)
            {
                PictureBox.Image = _imageManager.ProcessOcrResult(OcrResult);
            }
        }

        private void mnuSaveResult_Click(object sender, EventArgs e)
        {

        }

        private void DoSaveResult(string resultFileName)
        {
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
        }

        private void pictureBox_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (OcrResult == null) return;
            var words = OcrResult.Words.Where(i => i.Location.Y >= e.Y && i.Location.X >= e.X).OrderBy(o => o.Location.Y).ThenBy(o => o.Location.X).ToList();
            var word = words.FirstOrDefault();
            if (word == null) return;
            MessageBox.Show(word.Text, "OCR Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mnuRunOCR_Click(object sender, EventArgs e)
        {
            if (PictureFile == null || !PictureFile.Exists) OpenFile();
            DoOCR();
            ShowOCRBoxes();
            if (OcrResult != null)
            {
                LoadVisionTree(OcrResult);
                LoadText(OcrResult);
            }
        }

        private void ExtractFormValues()
        {
            DoOCR();
            //var options = GetMapping();
            //var docProvider = new DocumentProcesor(GetProvider(false));
            //var result = docProvider.DoProcess(File.ReadAllBytes(_fileName), _fileName, options, _result);
            //_processResult = result;
            //_resultImg = _imageManager.ProcessParseResult(result.TextResults);
            //PictureBox.Image = _resultImg;
            //listResult.Items.Clear();
            //foreach (var item in result.TextResults)
            //{
            //    var listItem = new ListViewItem(new string[] { item.Map.AttributeName, item.Value });
            //    listResult.Items.Add(listItem);
            //}
        }

        private void extractFormValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (PictureFile == null || !PictureFile.Exists) OpenFile();
            ExtractFormValues();

        }

        private void mnuExportToExcel_Click(object sender, EventArgs e)
        {
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
                //foreach (var result in _processResult.TextResults)
                //{
                //    sheet.Cells[row, 1].Value = result.Map.AttributeName;
                //    sheet.Cells[row, 2].Value = result.Value;
                //    row++;
                //}
                // Save to file
                package.Save();
            }
        }

        private void mnuConfiguration_Click(object sender, EventArgs e)
        {
            var configForm = new ConfigForm();
            configForm.DrawSearchArea += ConfigForm_DrawSearchArea;
            configForm.Show();
        }

        private void ConfigForm_DrawSearchArea(object sender, SearchAreaEventArgs e)
        {
            //TODO: Implement test logic
            if (OcrResult == null) DoOCR();
            var region = OcrResult.Regions.FirstOrDefault();
            var loc = FieldOption.FromRelative(OcrResult.Info.ToLocation(), e.Location);
            PictureBox.Image = _imageManager.DrawRegion(region, loc);
        }
    }
}
