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
    public partial class FieldExtractorControl : UserControl
    {

        private FieldExtractor _fieldExtractor;

        public FieldExtractorControl()
        {
            InitializeComponent();
            FieldExtractor = new FieldExtractor() { PostProcessing = new FieldExtractorPostProcessing() };
        }

        public FieldExtractor FieldExtractor { get { return _fieldExtractor; } set { _fieldExtractor = value; DoBinding(); } }

        public void DoBinding()
        {
            if (FieldExtractor == null) return;
            fieldExtractorBindingSource.DataSource = FieldExtractor;
            fieldExtractorBindingSource.ResetBindings(false);
            extractorData.Options.Name = FieldExtractor.ExtractorName;
            extractorData.Options.Options = FieldExtractor.ExtractorOptions.Select(i => new ExternalDataOptions() { Name = i.Key, Value = i.Value }).ToList();
            postProccesor.Options.Name = FieldExtractor.PostProcessing.PostProcessingName;
            postProccesor.Options.Options = FieldExtractor.PostProcessing.Options.Select(i => new ExternalDataOptions() { Name = i.Key, Value = i.Value }).ToList();
        }

        private void FieldExtractorControl_Load(object sender, EventArgs e)
        {

        }

        private void extractorData_DataChanged(object sender, EventArgs e)
        {
            if (FieldExtractor == null) return;
            FieldExtractor.ExtractorName = extractorData.Options.Name;
            FieldExtractor.ExtractorOptions = extractorData.Options.OptionsToDic();
        }

        private void postProccesor_DataChanged(object sender, EventArgs e)
        {
            if (FieldExtractor == null) return;
            FieldExtractor.PostProcessing.PostProcessingName = postProccesor.Options.Name;
            FieldExtractor.PostProcessing.Options = postProccesor.Options.OptionsToDic();
        }
    }
}
