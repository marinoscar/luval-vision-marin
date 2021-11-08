using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core
{
    public class WideLineResolver : IOcrLineResolver
    {
        private const float HorizontalLineMargin = 0.1f;


        public IEnumerable<OcrLine> GetLines(IEnumerable<OcrWord> words, IDictionary<string, string> options)
        {
            var lines = new List<OcrLine>();
            var sorted = words.OrderBy(i => i.Location.Y).ThenBy(i => i.Location.X).ToList();
            var id = 1;
            while (sorted.Count > 0)
            {
                var item = sorted.First();
                var minY = (int)(item.Location.Y - (item.Location.Y * HorizontalLineMargin));
                var maxY = (int)(item.Location.YBound + (item.Location.YBound * HorizontalLineMargin));
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
    }
}
