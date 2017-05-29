using System;
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
        public double OffsetY { get; set; }
        public double OffsetX { get; set; }
        public double RelativeOffsetY { get; set; }
        public double RelativeOffsetX { get; set; }
        public double ScalarRank { get; set; }
        public double AnchorRankMath { get; set; }

        public static MappingResult Create(ImageInfo info, AttributeMapping map, OcrElement anchor, OcrElement result)
        {
            return Create(info, map, anchor, result, null);
        }

        public static MappingResult Create(ImageInfo info, AttributeMapping map, OcrElement anchor, OcrElement result, string value, double rankMatch)
        {
            var items = new OcrElement[] { anchor, result };
            var loc = new OcrLocation()
            {
                X = items.Min(i => i.Location.X),
                Y = items.Min(i => i.Location.Y),
                Width = (items.Max(i => i.Location.XBound) - items.Min(i => i.Location.X)),
                Height = (items.Max(i => i.Location.YBound) - items.Min(i => i.Location.Y))
            };
            loc.RelativeLocation = OcrRelativeLocation.Load(loc, info);
            var res = new MappingResult()
            {
                Map = map,
                AnchorElement = anchor,
                ResultElement = result,
                Value = value,
                Location = loc,
                RelativeLocation = loc.RelativeLocation,
                OffsetX = Math.Abs(result.Location.X - anchor.Location.X),
                OffsetY = Math.Abs(result.Location.Y - anchor.Location.YBound),
                AnchorRankMath = rankMatch

            };
            return res;
        }
    }
}
