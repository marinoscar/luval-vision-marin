using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core
{
    public class CustomOcrLineResolver : IOcrLineResolver
    {
        public IEnumerable<OcrLine> GetLines(IEnumerable<OcrWord> words, IDictionary<string, string> options)
        {
            var top = GetValue(options, "topRelativeRange");
            var bottom = GetValue(options, "bottomRelativeRange");
            var lines = new List<OcrLine>();
            var sorted = words.OrderBy(i => i.Location.Y).ThenBy(i => i.Location.X).ToList();
            var id = 1;
            while (sorted.Count > 0)
            {
                var item = sorted.First();
                var minY = (int)(item.Location.Y - (item.Location.Y * top));
                var maxY = (int)(item.Location.Y + (item.Location.Y * bottom));
                var wordsInLine = sorted.Where(i => (i.Id != item.Id) && (i.Location.Y >= minY && i.Location.Y <= maxY)).OrderBy(i => i.Location.X).ToList();
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

        private double GetValue(IDictionary<string, string> options, string field)
        {
            if (options == null || !options.Keys.Any()) return 0d;
            if (!options.ContainsKey(field)) return 0d;
            var result = 0d;
            return double.TryParse(options[field], out result) ? result : 0d;
        }
    }
}
