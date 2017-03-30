using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class OcrRegion : OcrElement
    {
        public OcrRegion()
        {
            Lines = new List<OcrLine>();
        }
        public List<OcrLine> Lines { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Lines.ForEach(i => sb.AppendLine(i.Text));
            return sb.ToString();
        }
    }
}
