using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class OcrResult
    {
        public OcrResult()
        {
            Regions = new List<OcrRegion>();
            Words = new List<OcrElement>();
            Lines = new List<OcrLine>();
            HorizontalLines = new List<LineItem>();
        }

        public string Language { get; set; }
        public decimal TextAngle { get; set; }
        public string Orientation { get; set; }
        public ImageInfo Info { get; set; }
        public List<OcrRegion> Regions { get; set; }
        public List<OcrElement> Words { get; set; }
        public List<OcrLine> Lines { get; set; }
        public List<LineItem> HorizontalLines { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var line in HorizontalLines)
            {
                sb.AppendLine(line.ToText());
            }
            return sb.ToString();
        }
    }
}
