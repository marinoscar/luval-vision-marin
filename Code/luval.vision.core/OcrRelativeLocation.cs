using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrRelativeLocation : OcrLocation
    {
        public static OcrRelativeLocation Load(OcrLocation location, ImageInfo info)
        {
            var imgHalf = (info.Height / 2);
            var res = new OcrRelativeLocation()
            {
                X = Convert.ToInt32(((double)location.X / (double)info.Width) * 100),
                Y = Convert.ToInt32(((double)location.Y / (double)info.Height) * 100),
                Width = Convert.ToInt32(((double)location.Width / (double)info.Width) * 100),
                Height = Convert.ToInt32(((double)location.Height / (double)info.Height) * 100),
                IsTopHalf = (imgHalf > location.YBound)
            };
            res.Quadrant = GetQuadrant(res);
            res.HorizontalQuadrant = GetHQuadrant(res);
            res.VerticalQuadrant = GetVQuadrant(res);
            return res;
        }

        private static short GetQuadrant(OcrRelativeLocation location)
        {
            if (location.X <= 50 && location.Y <= 50) return 1;
            if (location.X > 50 && location.Y <= 50) return 2;
            if (location.X <= 50 && location.Y > 50) return 3;
            if (location.X > 50 && location.Y > 50) return 4;
            return 0;
        }

        private static short GetHQuadrant(OcrRelativeLocation location)
        {
            if (location.X <= 25) return 1;
            if (location.X > 25 && location.X <= 50) return 2;
            if (location.X > 50 && location.X <= 75) return 3;
            return 4;
        }

        private static short GetVQuadrant(OcrRelativeLocation location)
        {
            if (location.Y <= 25) return 1;
            if (location.Y > 25 && location.Y <= 50) return 2;
            if (location.Y > 50 && location.Y <= 75) return 3;
            return 4;
        }

        public bool IsTopHalf { get; set; }
        public short Quadrant { get; set; }
        public short HorizontalQuadrant { get; set; }
        public short VerticalQuadrant { get; set; }


    }
}
