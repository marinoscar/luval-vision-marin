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

namespace luval.vision.sink.Controls
{
    public partial class MappingControl : UserControl
    {
        public MappingControl()
        {
            InitializeComponent();
        }

        public List<AttributeMapping> Attributes { get; set; }
        public AttributeMapping SelectedAttribute { get; set; }


        public void DoLoad()
        {
            foreach(var att in Attributes)
            {
                cboAttribute.Items.Add(att.AttributeName);
            }
        }
    }
}
