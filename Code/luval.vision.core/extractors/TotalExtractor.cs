using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.extractors
{
    public class TotalExtractor : IExtractor<double?>
    {
        public List<OcrLine> Lines { get; private set; }

        public TotalExtractor(IEnumerable<OcrLine> lines)
        {
            Lines = new List<OcrLine>(lines);
        }

        public ExtractResult<double?> Extract()
        {
            var items = Lines.Where(i => i.Location.RelativeLocation.VerticalQuadrant >= 3
            && i.Location.RelativeLocation.HorizontalQuadrant > 2 && i.Entities.Select(e => e.Type).Contains(DataType.Amount)).ToList();
            var amount = items.SelectMany(i => i.Entities).Select(i => new { Value = DoParse(i.Text), Result = i })
            .OrderByDescending(i => i.Value).FirstOrDefault();
            return amount != null ? new ExtractResult<double?>()
            {
                Element = amount.Result.Element,
                Text = amount.Result.Text,
                Value = amount.Value
            } : default(ExtractResult<double?>);
        }

        private double? DoParse(string text)
        {
            var val = 0d;
            return double.TryParse(text, out val) ? val : default(double?);
        }
    }
}
