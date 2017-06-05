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
using Newtonsoft.Json;
using System.IO;

namespace luval.vision.sink.Controls
{
    public partial class MappingControl : UserControl
    {

        private KeysConverter _converter;
        private Configuration _config;


        public event EventHandler ValueMappingSelected;
        public event EventHandler AnchorMappingSelected;

        public MappingControl()
        {
            InitializeComponent();
            _converter = new KeysConverter();
            _config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }

        private ProcessResult Result { get; set; }
        public AttributeMapping SelectedAttribute { get; set; }
        public MappingResult SelectedMapping { get; set; }


        private void OnEventRaised(EventHandler ev, EventArgs e)
        {
            EventHandler handler = ev;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnValueMappingSelected(EventArgs e)
        {
            OnEventRaised(ValueMappingSelected, e);
        }

        protected virtual void OnAnchorMappingSelected(EventArgs e)
        {
            OnEventRaised(AnchorMappingSelected, e);
        }

        public void Initialize(ProcessResult result)
        {
            Result = result;
            DoLoad();
        }

        public void DoLoad()
        {
            foreach (var att in Result.Mappings)
            {
                cboAttribute.Items.Add(att.AttributeName);
                var res = Result.TextResults.FirstOrDefault(i => i.Map.AttributeName == att.AttributeName);
                if (res == null)
                {
                    Result.TextResults.Add(MappingResult.Create(att));
                }
            }
        }

        public void AcceptValueMapping(OcrLine value)
        {
            SelectedMapping.ResultElement = value;
            var extractor = new EntityExtractor(Result.OcrResult, Result.Mappings);
            SelectedMapping.Value = extractor.GetElementValue(SelectedAttribute, (OcrElement)value);
            CheckForMappingResultContent();
        }

        public void AcceptAnchorMapping(OcrLine anchor)
        {
            SelectedMapping.AnchorElement = anchor;
            CheckForMappingResultContent();
        }

        private void CheckForMappingResultContent()
        {
            if (!(SelectedMapping != null && SelectedMapping.AnchorElement != null && SelectedMapping.ResultElement != null)) return;
            SelectedMapping = MappingResult.Create(Result.ImageInfo, SelectedMapping.Map, SelectedMapping.AnchorElement, SelectedMapping.ResultElement, SelectedMapping.Value, 0d);
            LoadMapping(SelectedMapping.Map.AttributeName);
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
            if (!DoValidations()) return;
            var fileContent = JsonConvert.SerializeObject(Result);
            var fileName = string.Format("Result-{0}.celeris", Result.Id);
            File.WriteAllText(string.Format(@"{0}\{1}", WorkingDir.Result, fileName), fileContent);
            WorkingDir.MoveToProcessed(Result.ImageInfo.Name);
            MessageBox.Show(string.Format("Mapping has been saved to file {0} in the results folder", fileName), "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool DoValidations()
        {
            foreach (var map in Result.Mappings)
            {
                if (map.NotFound) return false;
                var res = Result.TextResults.FirstOrDefault(i => i.Map.AttributeName == map.AttributeName);
                if (res == null)
                {
                    ShowValidation(string.Format("Please enter information for attribute {0}", map.AttributeName));
                    return false;
                }
                if (res.AnchorElement == null)
                {
                    ShowValidation(string.Format("Please select anchor for attribute {0}", map.AttributeName));
                    return false;
                }
                if (res.ResultElement == null)
                {
                    ShowValidation(string.Format("Please select anchor for attribute {0}", map.AttributeName));
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtLines.Text))
            {
                ShowValidation(string.Format("Please enter the value for Lines Not Identified"));
                return false;
            }
            if (cboQuality.SelectedIndex < 0)
            {
                ShowValidation(string.Format("Please select the image category value"));
                return false;
            }
            return true;
        }

        private void ShowValidation(string text)
        {
            MessageBox.Show(text, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void LoadMapping(string attName)
        {
            SelectedAttribute = Result.Mappings.FirstOrDefault(i => i.AttributeName == attName);
            SelectedMapping = Result.TextResults.FirstOrDefault(i => i.Map.AttributeName == attName);
            if (SelectedMapping == null) return;
            if (SelectedMapping.ResultElement != null)
            {
                txtValueElement.Text = SelectedMapping.ResultElement.Text;
                txtValue.Text = SelectedMapping.Value;
            }
            if (SelectedMapping.AnchorElement != null)
            {
                txtAnchorText.Text = SelectedMapping.AnchorElement.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void txtLines_TextChanged(object sender, EventArgs e)
        {
            if (Result == null || !Result.OcrResult.Lines.Any()) return;
            var val = Convert.ToDouble(txtLines.Text);
            var count = Convert.ToDouble(Result.OcrResult.Lines.Count);
            txtPercentage.Text = string.Format("{0}%", Math.Round((1 - (val / (val + count))) * 100).ToString("N3"));

        }

        private void btnMapValue_Click(object sender, EventArgs e)
        {
            OnValueMappingSelected(e);
        }

        private void btnMapAnchor_Click(object sender, EventArgs e)
        {
            OnAnchorMappingSelected(e);
        }
    }
}
