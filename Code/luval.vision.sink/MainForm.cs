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
    public partial class MainForm : Form, IMainformPresenter
    {

        private string _fileName;
        private MainformPresenter _presenter;

        public MainForm()
        {
            InitializeComponent();
            _presenter = new MainformPresenter(this);
        }

        public PictureBox PictureBox { get { return pictureBox; } }
        public PropertyGrid PropertyGrid { get { return resultGrid; } }
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
                Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*",
                RestoreDirectory = true
            };
            if (dialog.ShowDialog() == DialogResult.Cancel) return;
            _fileName = dialog.FileName;
            _presenter.DoLoadImage(_fileName);
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
            var provider = new OcrProvider();
            var result = _presenter.ProcessFromFile(_fileName);
            _presenter.DoFullProcess(result);
        }



        private void btnDemo_Click(object sender, EventArgs e)
        {
            _presenter.DoLoadImage(@"Demo/sample-receipt.jpg");
            var response = File.ReadAllText(@"Demo/sample-response.json");
            var ocrResult = JsonConvert.DeserializeObject<OcrResult>(response);
            ocrResult.LoadFromJsonRegion();
            var items = GetData(ocrResult);
            _presenter.DoFullProcess(ocrResult);
            resultGrid.SelectedObject = items;

        }

        private IDictionary<string, string> GetData(OcrResult result)
        {
            var options = new List<AttributeMapping>() {
                new AttributeMapping() {  AttributeName = "Date" },
                new AttributeMapping() {  AttributeName = "DueDate", AttributeNamePattern = "Due Date" },
                new AttributeMapping() {  AttributeName = "Total", IsAttributeLast = true },
                new AttributeMapping() {  AttributeName = "Invoice" },
                new AttributeMapping() {  AttributeName = "Terms" },
                new AttributeMapping() {  AttributeName = "Attention" },
                new AttributeMapping() {  AttributeName = "BalanceDue", AttributeNamePattern = "Balance Due" },
            };
            var navigator = new Navigator(result.Lines, options);
            return navigator.ExtractAttributes();
        }
    }
}
