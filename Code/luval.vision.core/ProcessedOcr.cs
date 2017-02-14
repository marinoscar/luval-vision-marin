using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class ProcessedOcr
    {
        public ParseResult Result { get; set; }
        public OcrResult OcrValue { get; set; }
        public IEnumerable<LineItem> Lines { get; set; }

        public string ToText()
        {
            var sb = new StringBuilder();
            foreach(var line in Lines)
            {
                sb.AppendLine(line.ToText());
            }
            return sb.ToString();
        }
    }
}
