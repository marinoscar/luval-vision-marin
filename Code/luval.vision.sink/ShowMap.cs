using luval.vision.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luval.vision.sink
{
    public partial class ShowMap : Form
    {
        public ShowMap()
        {
            InitializeComponent();
        }

        private void ShowMap_Load(object sender, EventArgs e)
        {
            LoadUI();
        }


        public OcrResult OcrResult { get; set; }
        public MappingResult MappingResult { get; set; }

        public void LoadUI()
        {
            if (OcrResult == null) return;
            if (MappingResult != null)
            {
                LoadText();
            }
        }

        private void LoadText()
        {
            txtAnchor.Text = MappingResult.AnchorElement.Text;
            txtValue.Text = MappingResult.ResultElement.Text;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowList(false);
        }

        private void btnShowVal_Click(object sender, EventArgs e)
        {
            ShowList(true);
        }

        private void ShowList(bool isVal)
        {
            if (OcrResult == null) return;
            var frm = new MappingSelector()
            {
                Lines = OcrResult.Lines,
                SelectedId = isVal ? MappingResult.ResultElement.Id : MappingResult.AnchorElement.Id
            };
            frm.ShowDialog();
        }
    }

    public class CboItem
    {
        public string Text { get; set; }
        public int Id { get; set; }
        public OcrLine Item { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
