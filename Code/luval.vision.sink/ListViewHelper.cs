using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace luval.vision.sink
{
    public static class ListViewHelper
    {
        public static void Prepare(ListView view)
        {
            view.FullRowSelect = true;
            view.View = View.Details;
            view.MultiSelect = false;
            foreach(var col in view.Columns.Cast<ColumnHeader>())
            {
                col.Width = -2;
            }
        }
    }
}
