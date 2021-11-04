using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrLoaderHelper
    {
        public static string GetRegionCode(int id)
        {
            return id.ToString().PadLeft(3, '0');
        }

        public static string GetLineCode(int id, OcrElement region)
        {
            return string.Format("{0}.{1}", region.Code, id.ToString().PadLeft(4, '0'));
        }

        public static string GetWordCode(int id, OcrElement line)
        {
            return string.Format("{0}.{1}", line.Code, id.ToString().PadLeft(5, '0'));
        }

        public static List<OcrLine> GetLines(List<OcrWord> words, OcrRegion region, ImageInfo info)
        {
            var lineId = 1;
            var lines = new List<OcrLine>();
            var horLines = Navigator.GetWordsHorizontallyAligned(words, HorizontalLineMargin);
            foreach (var line in horLines)
            {
                line.ParentRegion = region;
                //line.Location.X = line.Words.Min(i => i.Location.X);
                //line.Location.Y = line.Words.Max(i => i.Location.Y);
                //line.Location.Height = line.Words.Max(i => i.Location.YBound) - line.Location.Y;
                //line.Location.Width = line.Words.Max(i => i.Location.XBound) - line.Location.X;
                line.Location = GetLocationFromElements(line.Words);
                line.Location.RelativeLocation = OcrRelativeLocation.Load(line.Location, info);
                line.Code = OcrLoaderHelper.GetLineCode(lineId, region);
                lines.Add(line);
                lineId++;
            }
            return lines;
        }

        public static List<OcrLine> GetLines2(List<OcrWord> words, OcrRegion region, ImageInfo info)
        {
            var lineId = 1;
            var lines = new List<OcrLine>();
            var horLines = Navigator.GetWordsHorizontallyAligned2(words, HorizontalLineMargin);
            foreach (var line in horLines)
            {
                line.ParentRegion = region;
                //line.Location.X = line.Words.Min(i => i.Location.X);
                //line.Location.Y = line.Words.Max(i => i.Location.Y);
                //line.Location.Height = line.Words.Max(i => i.Location.YBound) - line.Location.Y;
                //line.Location.Width = line.Words.Max(i => i.Location.XBound) - line.Location.X;
                line.Location = GetLocationFromElements(line.Words);
                line.Location.RelativeLocation = OcrRelativeLocation.Load(line.Location, info);
                line.Code = OcrLoaderHelper.GetLineCode(lineId, region);
                lines.Add(line);
                lineId++;
            }
            return lines;
        }

        public static OcrLocation GetLocationFromElements(IEnumerable<OcrElement> elements)
        {
            return new OcrLocation()
            {
                X = elements.Min(i => i.Location.X),
                Y = elements.Max(i => i.Location.Y),
                Height = elements.Max(i => i.Location.YBound) - elements.Max(i => i.Location.Y),
                Width = elements.Max(i => i.Location.XBound) - elements.Min(i => i.Location.X)
            };
        }

        private const float HorizontalLineMargin = 0.025f;
    }
}
