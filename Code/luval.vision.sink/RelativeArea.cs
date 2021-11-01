using OfficeOpenXml.FormulaParsing.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luval.vision.sink
{
    public partial class RelativeArea : Form
    {
        public RelativeArea()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtX_KeyDown(object sender, KeyEventArgs e)
        {
             //if (!e.IsNumeric()) e.SuppressKeyPress = true;
        }

        private void RelativeArea_Load(object sender, EventArgs e)
        {

        }

        public double X { get { return Convert.ToDouble(txtX.Text); }  }
        public double XBound { get { return Convert.ToDouble(txtXTop.Text); } }
        public double Y { get { return Convert.ToDouble(txtY.Text); } }
        public double YBound { get { return Convert.ToDouble(txtYTop.Text); } }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
