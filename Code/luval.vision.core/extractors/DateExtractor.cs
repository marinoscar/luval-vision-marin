using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.extractors
{
    public class DateExtractor : IExtractor<DateTime?>
    {

        private CultureInfo _es;
        private CultureInfo _en;
        private List<string> _formats;

        public DateExtractor(IEnumerable<OcrLine> lines)
        {
            Lines = new List<OcrLine>(lines);
            _es = CultureInfo.GetCultureInfo("es");
            _en = CultureInfo.GetCultureInfo("en");
        }

        public List<OcrLine> Lines { get; set; }

        public ExtractResult<DateTime?> Extract()
        {
            var items = Lines.Where(i => i.Location.RelativeLocation.IsTopHalf)
                .SelectMany(i => i.Entities).Where(i => i.Type == DataType.Date)
                .Select(i => new ExtractResult<DateTime?>()
                {
                    Element = i.Element,
                    Text = i.Text,
                    Value = ParseDate(i.Text)
                }).Where(i => i.Value != null).OrderBy(i => i.Value).ToList();
            return items.FirstOrDefault();
        }

        private DateTime? ParseDate(string text)
        {    
            var dt = default(DateTime);
            var res = DateTime.TryParse(text, _en, DateTimeStyles.AssumeLocal | DateTimeStyles.AllowInnerWhite | DateTimeStyles.AllowLeadingWhite | DateTimeStyles.AllowWhiteSpaces, out dt);
            if (res) return dt;
            res = DateTime.TryParse(text, _es, DateTimeStyles.AssumeLocal, out dt);
            return res ? dt : default(DateTime?);
        }
    }
}
