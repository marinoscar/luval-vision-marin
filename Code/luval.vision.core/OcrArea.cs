using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrArea
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public string[] Words { get; set; }

        public string ToText()
        {
            return string.Join(" ", Words);
        }
    }
}
