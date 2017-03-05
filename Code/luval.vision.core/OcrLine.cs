using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLine
    {
        public OcrLine()
        {
            Words = new List<OcrWord>();
        }

        public OcrRegion ParentRegion { get; set; }
        public OcrLocation Location { get; set; }
        public List<OcrWord> Words { get; set; }
    }
}
