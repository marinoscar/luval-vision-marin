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
            res.HorizontalThird = GetRelativePositionIndex(res.X, 3);
            res.HorizontalQuadrant = GetRelativePositionIndex(res.X, 4);
            res.HorizontalSixth = GetRelativePositionIndex(res.X, 6);
            res.HorizontalEight = GetRelativePositionIndex(res.X, 8);
            res.VerticalQuadrant = GetRelativePositionIndex(res.Y, 4);
            res.VerticalThird = GetRelativePositionIndex(res.Y, 3);
            res.VerticalQuadrant = GetRelativePositionIndex(res.Y, 4);
            res.VerticalSixth = GetRelativePositionIndex(res.Y, 6);
            res.VerticalEight = GetRelativePositionIndex(res.Y, 8);
            return res;
        }

        public static OcrLocation FromRelative(OcrLocation workingArea, double x, double xbound, double y, double ybound)
        {
            return new OcrLocation()
            {
                X = (int)(workingArea.Width * x),
                Width = (int)((workingArea.Width * xbound)-(workingArea.Width * x)),
                Y = (int)(workingArea.Height * y),
                Height = (int)((workingArea.Height * ybound)-(workingArea.Height * y)),
            };
        }

        private static short GetQuadrant(OcrRelativeLocation location)
        {
            if (location.X <= 50 && location.Y <= 50) return 1;
            if (location.X > 50 && location.Y <= 50) return 2;
            if (location.X <= 50 && location.Y > 50) return 3;
            if (location.X > 50 && location.Y > 50) return 4;
            return 0;
        }

        private static short GetRelativePositionIndex(int location, short slices)
        {
            var sliceSize = 100d / (double)slices;
            return Convert.ToInt16(Math.Floor((double)location / sliceSize) + 1);
        }

        public bool IsTopHalf { get; set; }
        public short Quadrant { get; set; }
        public short HorizontalQuadrant { get; set; }
        public short VerticalQuadrant { get; set; }

        public short VerticalThird { get; set; }
        public short HorizontalThird { get; set; }
        public short VerticalSixth { get; set; }
        public short HorizontalSixth { get; set; }
        public short VerticalEight { get; set; }
        public short HorizontalEight { get; set; }


    }
}
