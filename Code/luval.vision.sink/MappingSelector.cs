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
    public partial class MappingSelector : Form
    {
        public MappingSelector()
        {
            InitializeComponent();
        }

        private void MappingSelector_Load(object sender, EventArgs e)
        {
            if (Lines == null || !Lines.Any()) return;
            LoadLines();
        }

        private void LoadLines()
        {
            listView.Items.Clear();
            var selectedItem = default(ListViewItem);
            foreach (var line in Lines)
            {
                var item = new ListViewItem(new string[] { line.Id.ToString(), line.Text }) { Tag = line };
                listView.Items.Add(item);
                if (SelectedId == line.Id) selectedItem = item;
            }
            if(selectedItem != null)
            {
                selectedItem.Selected = true;
                selectedItem.EnsureVisible();
            }
            ListViewHelper.Prepare(listView);
        }

        public IEnumerable<OcrLine> Lines { get; set; }
        public int SelectedId { get; set; }
    }
}
