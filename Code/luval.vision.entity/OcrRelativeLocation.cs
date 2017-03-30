using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class OcrRelativeLocation : OcrLocation
    {
        public static OcrRelativeLocation Load(OcrLocation location, ImageInfo info)
        {
            var res = new OcrRelativeLocation()
            {
                X = location.X / info.Width,
                Y = location.Y / info.Height,
                Width = location.Width / info.Width,
                Height = location.Height / info.Height,
                IsTopHalf = ((info.Height / 2) <= location.Y)
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
