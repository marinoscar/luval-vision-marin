﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class OcrElement
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public virtual OcrLocation Location { get; set; }
        public virtual string Text { get; set; }
    }
}
