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
        public event EventHandler SaveAndNew;

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

        protected virtual void OnSaveAndNew(EventArgs e)
        {
            OnEventRaised(SaveAndNew, e);
        }

        public void Initialize(ProcessResult result)
        {
            Clear();
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

        public void Clear()
        {
            Result = null;
            SelectedAttribute = null;
            SelectedMapping = null;
            cboAttribute.Items.Clear();
            txtAnchorText.Text = null;
            txtComments.Text = null;
            txtLines.Text = null;
            txtPercentage.Text = null;
            txtValue.Text = null;
            txtValueElement.Text = null;
            lblInstructions.Text = "Instructions";
            cboQuality.SelectedIndex = -1;
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
            if (!(SelectedMapping != null && SelectedMapping.ResultElement != null)) return;
            SelectedMapping = MappingResult.Create(Result.ImageInfo, SelectedMapping.Map, SelectedMapping.AnchorElement, SelectedMapping.ResultElement, SelectedMapping.Value, 0d);
            LoadMapping(SelectedMapping.Map.AttributeName);
        }

        private void txtLines_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete || 
                e.KeyData == Keys.NumPad0 || e.KeyData == Keys.NumPad1 || e.KeyData == Keys.NumPad2 ||
                e.KeyData == Keys.NumPad3 || e.KeyData == Keys.NumPad4 || e.KeyData == Keys.NumPad5 ||
                e.KeyData == Keys.NumPad6 || e.KeyData == Keys.NumPad7 || e.KeyData == Keys.NumPad8 ||
                e.KeyData == Keys.NumPad9) return;
            var val = "0123456879";
            var s = _converter.ConvertToString(e.KeyData);
            e.SuppressKeyPress = !val.Contains(s);
        }

        private void cboAttribute_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadMapping(Convert.ToString(cboAttribute.SelectedItem));
        }

        private void DoSave()
        {
            if (!DoValidations()) return;
            Result.UnIdentifiedLines = Convert.ToInt32(txtLines.Text);
            Result.QualityType = cboQuality.SelectedIndex + 1;
            Result.Comment = txtComments.Text;
            var fileContent = JsonConvert.SerializeObject(Result);
            var fileName = string.Format("Result-{0}.celeris", Result.Id);
            File.WriteAllText(string.Format(@"{0}\{1}", WorkingDir.Result, fileName), fileContent);
            WorkingDir.MoveToProcessed(Result.ImageInfo.Name);
            var message = string.Format("Mapping has been saved to file {0} in the results folder.\nDo you want to load another file", fileName);
            if(MessageBox.Show(message, "Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Clear();
                OnSaveAndNew(new EventArgs());
            }
        }

        private bool DoValidations()
        {
            foreach (var result in Result.TextResults)
            {
                if (result.NotFound) continue;
                if (result.ElementTextNotFound) continue;
                {
                    if (result.AnchorElement == null)
                    {
                        ShowValidation(string.Format("Please select anchor for attribute {0}", result.Map.AttributeName));
                        return false;
                    }
                    if (result.ResultElement == null)
                    {
                        ShowValidation(string.Format("Please select anchor for attribute {0}", result.Map.AttributeName));
                        return false;
                    }
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
            lblInstructions.Text = "Instructions";
            SelectedAttribute = Result.Mappings.FirstOrDefault(i => i.AttributeName == attName);
            SelectedMapping = Result.TextResults.FirstOrDefault(i => i.Map.AttributeName == attName);
            if (SelectedMapping == null) return;
            if (SelectedMapping.ResultElement != null)
            {
                txtValueElement.Text = SelectedMapping.ResultElement.Text;
                txtValue.Text = SelectedMapping.Value;
            }
            else
            {
                txtValueElement.Text = null;
                txtValue.Text = null;
            }
            if (SelectedMapping.AnchorElement != null)
                txtAnchorText.Text = SelectedMapping.AnchorElement.Text;
            else
                txtAnchorText.Text = null;
            chkNotCaptured.Checked = SelectedMapping.ElementTextNotFound;
            chkNotFound.Checked = SelectedMapping.NotFound;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DoSave();
        }

        private void txtLines_TextChanged(object sender, EventArgs e)
        {
            if (Result == null || !Result.OcrResult.Lines.Any() || string.IsNullOrWhiteSpace(txtLines.Text) || SelectedMapping == null) return;
            var val = Convert.ToDouble(txtLines.Text);
            var count = Convert.ToDouble(Result.OcrResult.Lines.Count);
            txtPercentage.Text = string.Format("{0}%", Math.Round((1 - (val / (val + count))) * 100).ToString("N3"));

        }

        private void btnMapValue_Click(object sender, EventArgs e)
        {
            if(cboAttribute.SelectedIndex < 0)
            {
                ShowValidation("Please select an attribute to map");
                return;
            }
            lblInstructions.Text = "Double Click on Element to Select the Value";
            OnValueMappingSelected(e);
        }

        private void btnMapAnchor_Click(object sender, EventArgs e)
        {
            if (cboAttribute.SelectedIndex < 0)
            {
                ShowValidation("Please select an attribute to map");
                return;
            }
            lblInstructions.Text = "Double Click on Element to Select the Anchor";
            OnAnchorMappingSelected(e);
        }

        private void chkNotFound_Click(object sender, EventArgs e)
        {
            if (SelectedMapping == null) return;
            SelectedMapping.NotFound = chkNotFound.Checked;
        }

        private void chkNotCaptured_Click(object sender, EventArgs e)
        {
            if (SelectedMapping == null) return;
            SelectedMapping.ElementTextNotFound = chkNotCaptured.Checked;
        }
    }
}
