using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLine : OcrElement
    {
        public OcrLine()
        {
            Words = new List<OcrElement>();
        }

        public OcrRegion ParentRegion { get; set; }
        public List<OcrElement> Words { get; set; }
        public override string Text { get { return string.Join(" ", Words.Select(i => i.Text)); } }
    }
}
