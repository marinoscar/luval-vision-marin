using luval.vision.core.extractors;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.resolvers.custom
{
    public class RepIdResolver : RegexExtractor
    {
        public override IEnumerable<string> GetValue(string text, IDictionary<string, string> options)
        {
            if (string.IsNullOrWhiteSpace(text)) new List<string>();
            var textToWork = text
                .Replace("Paragraphs 1, 3 and 19", "")
                .Replace("Paragraphs 1, 3, 7 and 19", "")
                .Replace("and 19", "")
                .Replace("Section 1", "")
                .Replace("Section 5", "")
                .Replace("1.800", "")
                .Replace(".7343.", "");
            return base.GetValue(textToWork, options);
        }
    }
}
