using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using luval.vision.core;
using System.Configuration;

namespace luval.vision.sink.Controls
{
    public partial class MappingControl : UserControl
    {

        private KeysConverter _converter;
        private Configuration _config;
        public MappingControl()
        {
            InitializeComponent();
            _converter = new KeysConverter();
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        public List<AttributeMapping> Attributes { get; set; }
        public AttributeMapping SelectedAttribute { get; set; }
        public List<MappingResult> Mappings { get; set; }
        public MappingResult SelectedMapping { get; set; }


        public void DoLoad()
        {
            foreach(var att in Attributes)
            {
                cboAttribute.Items.Add(att.AttributeName);
            }
        }

        private void txtLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) return;
            var val = "0123456879";
            var s = _converter.ConvertToString(e.KeyData);
            e.SuppressKeyPress = !val.Contains(s); 

        }

        private void cboAttribute_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadMapping(cboAttribute.SelectedText);
        }

        private void DoSave()
        {

        }

        private void LoadMapping(string attName)
        {
            SelectedAttribute = Attributes.FirstOrDefault(i => i.AttributeName == attName);
            SelectedMapping = Mappings.FirstOrDefault(i => i.Map.AttributeName == attName);
            if (SelectedMapping == null) return;
            if(SelectedMapping.ResultElement != null)
            {
                txtValueElement.Text = SelectedMapping.ResultElement.Text;
                txtValue.Text = SelectedMapping.Value;
            }
            if(SelectedMapping.AnchorElement != null)
            {
                txtAnchorText.Text = SelectedMapping.AnchorElement.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
