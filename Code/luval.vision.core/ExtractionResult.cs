using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core
{
    public class ExtractionResult
    {
        public OcrElement Element { get; set; }
        public string Value { get; set; }
        public FieldOption Option { get; set; }
    }
}
