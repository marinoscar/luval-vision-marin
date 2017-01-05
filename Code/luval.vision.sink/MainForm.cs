using luval.vision.core;
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

        public MainForm()
        {
            InitializeComponent();
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
            pictureBox.Image = null;
            if (File.Exists("tmp.img")) File.Delete("tmp.img");
            File.Copy(dialog.FileName, "tmp.img", true);
            var image = Image.FromFile("tmp.img");
            pictureBox.Image = image;
            pictureBox.Refresh();
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
            var result = provider.DoOcr(_fileName);
            var bmp = new ImageManager().Process(result, pictureBox.Image);
            pictureBox.Image = bmp;
            var items = provider.GetLines(result);
            resultText.Lines = items.Select(i => i.ToText()).ToArray();
            resultText.AppendText(InvoiceData.FromOcr(items).ToString());
        }
    }
}
