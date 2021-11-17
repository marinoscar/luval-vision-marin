using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core
{
    public class RangeLineResolver : IOcrLineResolver
    {
        public IEnumerable<OcrLine> GetLines(IEnumerable<OcrWord> words, IDictionary<string, string> options)
        {
            var lines = new List<OcrLine>();
            var sorted = words.OrderBy(i => i.Location.Y).ThenBy(i => i.Location.X).ToList();
            var topOffSet = GetTopOffset(options);
            var bottomOffSet = GetBottomOffset(options);
            var id = 1;
            while (sorted.Count > 0)
            {
                var item = sorted.First();
                var minY = (int)(item.Location.Y);
                var maxY = (int)(item.Location.YBound);
                if (topOffSet != 0) minY = (int)(minY * topOffSet);
                if (bottomOffSet != 0) maxY = (int)(maxY * bottomOffSet);
                var wordsInLine = sorted.Where(i => (i.Id != item.Id) && (i.Location.Y >= minY && i.Location.YBound <= maxY)).OrderBy(i => i.Location.X).ToList();
                wordsInLine.Insert(0, item);
                lines.Add(new OcrLine()
                {
                    Id = id,
                    Words = wordsInLine.OrderBy(i => i.Location.X).ToList(),
                    Location = OcrLoaderHelper.GetLineLocation(wordsInLine)
                });
                wordsInLine.ForEach(i => sorted.Remove(i));
            }
            return lines;
        }

        private double GetTopOffset(IDictionary<string, string> options)
        {
            if (options == null || !options.ContainsKey("topOffset")) return 1d;
            var offset = 1d;
            if (double.TryParse(options["topOffset"], out offset)) return offset;
            return 1d;
        }

        private double GetBottomOffset(IDictionary<string, string> options)
        {
            if (options == null || !options.ContainsKey("bottomOffset")) return 1d;
            var offset = 1d;
            if (double.TryParse(options["bottomOffset"], out offset)) return offset;
            return 1d;
        }
    }
}
