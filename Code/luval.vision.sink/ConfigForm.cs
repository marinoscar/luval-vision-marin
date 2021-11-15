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
            ShowFieldOptionForm(newOption);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadConfigurationFile(GetConfigurationFile());
        }

        private string GetConfigurationFile()
        {
            var dlg = new OpenFileDialog()
            {
                Title = "Load configuration file",
                Filter = "Json Files (*.json)|*.json",
                Multiselect = false,
                RestoreDirectory = true
            };
            if (dlg.ShowDialog() != DialogResult.OK) return null;
            if (!File.Exists(dlg.FileName))
            {
                MessageBox.Show("Invalid file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return dlg.FileName;
        }

        private void LoadConfigurationFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName) || !File.Exists(fileName)) throw new ArgumentException(string.Format("Invalid file name: {0}", fileName));
            ConfigOptions = JsonConvert.DeserializeObject<ConfigOptions>(File.ReadAllText(fileName));
            fieldOptionBindingSource.ResetBindings(false);
        }

        private void dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 2)
            {
                ShowFieldOptionForm(GetRow(e.RowIndex));
            }
        }

        private void ShowFieldOptionForm(FieldOption fieldOption)
        {
            var frmOption = new FieldOptionForm() { FieldOption = fieldOption };
            frmOption.Show();
        }

        private FieldOption GetRow(int rowIndex)
        {
            var items = fieldOptionBindingSource.List as IList<FieldOption>;
            if (rowIndex < 0 || rowIndex > items.Count) throw new ArgumentOutOfRangeException("Unable to select the field option since is out of range");
            return items[rowIndex];
        }
    }
}
