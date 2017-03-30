using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLine : OcrElement
    {

        private string  _text;
        public OcrLine()
        {
            Words = new List<OcrWord>();
            ParentRegion = new OcrRegion();
        }

        public OcrRegion ParentRegion { get; set; }
        public List<OcrWord> Words { get; set; }
        public override string Text
        {
            get
            {
                if (Words != null && Words.Any())
                    return string.Join(" ", Words.Select(i => i.Text));
                else
                    return _text;
            }
            set
            {
                _text = value;
            }
        }
    }
}
