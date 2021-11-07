
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrRegion : OcrElement
    {

        public OcrRegion()
        {
            Words = new List<OcrWord>();
        }
        public IEnumerable<OcrWord> Words { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Words.ToList().ForEach(i => sb.AppendLine(i.Text));
            return sb.ToString();
        }
    }
}
