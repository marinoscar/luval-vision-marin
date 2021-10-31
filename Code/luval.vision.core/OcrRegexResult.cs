using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace luval.vision.core
{
    public class OcrRegexResult
    {
        public OcrElement Element { get; set; }
        public string RegExPattern { get; set; }
        public Match Match { get; set; }
    }
}
