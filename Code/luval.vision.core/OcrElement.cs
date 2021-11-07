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
            Location = new OcrLocation();
        }
        public int Id { get; set; }
        public string Code { get; set; }
        public virtual OcrLocation Location { get; set; }
        public virtual string Text { get; set; }

        public double GetCharSpacing()
        {
            if (Location == null) return 0d;
            if (string.IsNullOrWhiteSpace(Text)) return 0d;
            return Location.Width / Text.Length;
        }
    }
}
