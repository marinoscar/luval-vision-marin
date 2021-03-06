﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class MappingResult
    {
        public AttributeMapping Map { get; set; }
        public OcrElement AnchorElement { get; set; }
        public OcrElement ResultElement { get; set; }
        public OcrLocation Location { get; set; }
        public OcrRelativeLocation RelativeLocation { get; set; }
        public string Value { get; set; }
    }
}
