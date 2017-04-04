using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrResult
    {
        public OcrResult()
        {
            Regions = new List<OcrRegion>();
            Words = new List<OcrWord>();
            Lines = new List<OcrLine>();
            HorizontalLines = new List<OcrLine>();
            Entities = new List<OcrEntity>();
        }

        public string Language { get; set; }
        public decimal TextAngle { get; set; }
        public string Orientation { get; set; }
        public ImageInfo Info { get; set; }
        public List<OcrRegion> Regions { get; set; }
        public List<OcrWord> Words { get; set; }
        public List<OcrLine> Lines { get; set; }
        public List<OcrLine> HorizontalLines { get; set; }
        public List<OcrEntity> Entities { get; set; }


        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach(var line in HorizontalLines)
            {
                sb.AppendLine(line.Text);
            }
            return sb.ToString();
        }
    }
}
