using OfficeOpenXml.FormulaParsing.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using luval.vision.core;

namespace luval.vision.app
{
    public partial class SearchAreaControl : UserControl
    {

        private OcrRelativeSearchLocation _searchLocation;


        public SearchAreaControl()
        {
            InitializeComponent();
            SearchLocation = new OcrRelativeSearchLocation();
        }

        public OcrRelativeSearchLocation SearchLocation { get { return _searchLocation; } set { _searchLocation = value; DoBinding(); } }

        public void DoBinding()
        {
            if (SearchLocation == null) return;
            ocrRelativeSearchLocationBindingSource.DataSource = SearchLocation;
            ocrRelativeSearchLocationBindingSource.ResetBindings(false);
        }

        private void Text_KeyDown(object sender, KeyEventArgs e)
        {
            var txt = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txt.Text)) return;
            if (e.KeyCode == Keys.Oemcomma || e.KeyCode == Keys.OemPeriod || 
                e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab 
                || e.KeyCode == Keys.Shift || e.KeyCode == Keys.ShiftKey) 
                return;
            if (txt.Text.IsNumericValue()) e.SuppressKeyPress = true;
        }
    }
}
