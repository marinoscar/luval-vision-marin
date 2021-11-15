using luval.vision.core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luval.vision.app
{
    public partial class FieldOptionForm : BaseForm
    {


        public event EventHandler ApplyChanges;

        private FieldOption _fieldOption;
        public FieldOptionForm()
        {
            InitializeComponent();
            FieldOption = new FieldOption()
            {
                FieldAnchor = new FieldAnchor(),
                FieldExtractor = new FieldExtractor(),
                SearchArea = new OcrRelativeSearchLocation(),
                LineResolver = new FieldLineResolver()
            };
            FieldOption.FieldExtractor.PostProcessing = new FieldExtractorPostProcessing();
        }

        public FieldOption FieldOption { get { return _fieldOption; } set { _fieldOption = value; DoBinding(); } }

        protected virtual void OnApplyChanges(EventArgs e)
        {
            EventHandler handler = ApplyChanges;
            handler?.Invoke(this, e);
        }

        public void DoBinding()
        {
            if (FieldOption == null) return;
            fieldOptionBindingSource.DataSource = FieldOption;
            anchorControl.FieldAnchor = FieldOption.FieldAnchor;
            extractorControl.FieldExtractor = FieldOption.FieldExtractor;
            searchAreaControl.SearchLocation = FieldOption.SearchArea;
            linResolverControl.LineResolver = FieldOption.LineResolver;
            fieldOptionBindingSource.ResetBindings(false);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            OnApplyChanges(new EventArgs());
            Close();
        }
    }
}
