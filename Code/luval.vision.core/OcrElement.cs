using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrElement
    {

        public OcrElement()
        {
            Location = new OcrLocation() { RelativeLocation = new OcrRelativeLocation() };
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public virtual OcrLocation Location { get; set; }
        public virtual string Text { get; set; }
    }
}
