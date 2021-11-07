using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLine : OcrElement
    {

        private string _text;
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
                if (string.IsNullOrWhiteSpace(_text) && Words != null && Words.Any())
                {
                    _text = string.Join(" ", Words.Select(i => i.Text));
                    return _text;
                }
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
