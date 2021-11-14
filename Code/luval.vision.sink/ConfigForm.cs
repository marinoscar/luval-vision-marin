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
    public partial class ConfigForm : BaseForm
    {
        public ConfigForm()
        {
            InitializeComponent();
            ConfigOptions = new ConfigOptions();
            DoBinding();
        }

        public ConfigOptions ConfigOptions { get; set; }

        public void DoBinding()
        {
            fieldOptionBindingSource.DataSource = ConfigOptions.Fields;
            fieldOptionBindingSource.ResetBindings(false);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var newOption = new FieldOption() { FieldAnchor = new FieldAnchor(), FieldExtractor = new FieldExtractor(), LineResolver = new FieldLineResolver(), SearchArea = new OcrRelativeSearchLocation() };
            ConfigOptions.Fields.Add(new FieldOption());
            var frmOption = new FieldOptionForm() { FieldOption = newOption };
            frmOption.Show();
        }
    }
}
