using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLocation
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int YBound { get { return Y + Height;  } }
        public int XBound { get { return X + Width; } }

        public OcrRelativeLocation RelativeLocation { get; set; }

        public override string ToString()
        {
            return string.Format("X: {0} Y: {1} Width: {2} Height: {3}", X, Y, Width, Height);
        }

    }
}
