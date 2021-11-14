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

namespace luval.vision.app
{
    public partial class FieldAnchorControl : UserControl
    {

        private FieldAnchor _fieldAnchor;

        public FieldAnchorControl()
        {
            InitializeComponent();
            _fieldAnchor = new FieldAnchor();
            
        }

        private void UpdateBind()
        {
            if (FieldAnchor == null) return;
            fieldAnchorBindingSource.DataSource = FieldAnchor;
            stringForGridBindingSource.DataSource = FieldAnchor.Patterns.Select(i => new StringForGrid(i)).ToList();
            fieldAnchorBindingSource.ResetBindings(false);
            stringForGridBindingSource.ResetBindings(false);
        }

        public FieldAnchor FieldAnchor { get { return _fieldAnchor; } set { _fieldAnchor = value; UpdateBind(); } }

        private void stringForGridBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (FieldAnchor == null) return;
            var data = (IEnumerable<StringForGrid>)stringForGridBindingSource.List;
            FieldAnchor.Patterns = data.Select(i => i.ToString()).ToList();

        }
    }
}
