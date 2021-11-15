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
        public event EventHandler<SearchAreaEventArgs> DrawSearchArea;

        protected virtual void OnDrawSearchArea(SearchAreaEventArgs e)
        {
            EventHandler<SearchAreaEventArgs> handler = DrawSearchArea;
            handler?.Invoke(this, e);
        }

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

        private void btnTest_Click(object sender, EventArgs e)
        {
            OnDrawSearchArea(new SearchAreaEventArgs(SearchLocation));
        }

        private void Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }

    public class SearchAreaEventArgs : EventArgs
    {
        public SearchAreaEventArgs(OcrRelativeSearchLocation location)
        {
            Location = location;
        }
        public OcrRelativeSearchLocation Location { get; private set; }
    }

}
