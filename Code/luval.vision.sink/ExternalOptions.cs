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
    public partial class ExternalOptions : UserControl
    {
        public delegate void DataChangedEventHandler(object sender, EventArgs e);
        public event DataChangedEventHandler DataChanged;

        private ExternalCallAndOptions _options;

        public ExternalOptions()
        {
            InitializeComponent();
            Options = new ExternalCallAndOptions();
            externalCallAndOptionsBindingSource.DataSource = Options;
        }

        public string NameLabel { get { return lblName.Text; } set { lblName.Text = value; } }
        public string OptionsLabel { get { return grpBox.Text; } set { grpBox.Text = value; } }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ExternalCallAndOptions Options { get { return _options; } set { _options = value; DoBinding(); } }

        public void DoBinding()
        {
            if (Options == null) return;
            externalCallAndOptionsBindingSource.DataSource = Options;
            externalCallAndOptionsBindingSource.ResetBindings(true);

        }

        private void optionsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            DataChanged?.Invoke(this, new EventArgs());
        }

        private void externalCallAndOptionsBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            DataChanged?.Invoke(this, new EventArgs());
        }
    }
}
