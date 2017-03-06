using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrElement
    {
        public virtual OcrLocation Location { get; set; }
        public virtual string Text { get; set; }
    }
}
