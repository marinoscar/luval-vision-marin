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
    public partial class LineResolverControl : UserControl
    {
        private FieldLineResolver _lineResolver;

        public LineResolverControl()
        {
            InitializeComponent();
        }

        public FieldLineResolver LineResolver { get { return _lineResolver; } set { _lineResolver = value; DoBinding(); } }

        public void DoBinding()
        {
            if (LineResolver == null) return;
            externalOptions.Options.Name = LineResolver.LineResolverQualifiedName;
            externalOptions.Options.Options = LineResolver.Options.Select(i => new ExternalDataOptions() { Name = i.Key, Value = i.Value }).ToList();
        }

        private void externalOptions_DataChanged(object sender, EventArgs e)
        {
            LineResolver.LineResolverQualifiedName = externalOptions.Options.Name;
            LineResolver.Options = externalOptions.Options.OptionsToDic();
        }
    }
}
