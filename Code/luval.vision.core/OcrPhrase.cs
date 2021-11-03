using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class OcrPhrase : OcrElement
    {
        public OcrPhrase()
        {
            Words = new List<OcrWord>();
        }
        public OcrLine ParentLine { get; set; }
        public List<OcrWord> Words { get; set; }

    }
}
