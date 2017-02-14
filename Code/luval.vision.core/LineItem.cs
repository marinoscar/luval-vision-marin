using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class LineItem
    {
        public int LineNumber { get; set; }

        public IEnumerable<OcrArea> Areas { get; set; }
        public string ToText()
        {
            return string.Join("        ", Areas.Select(i => i.ToText()));
        }

        public int GetY()
        {
            return Areas.Select(i => i.Y).Min();
        }
    }
}
