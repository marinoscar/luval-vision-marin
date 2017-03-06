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
            Lines = new List<OcrLine>();
        }
        public int RegionId { get; set; }
        public List<OcrLine> Lines { get; set; }
    }
}
