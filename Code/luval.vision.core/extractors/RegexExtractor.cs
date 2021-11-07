using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace luval.vision.core.extractors
{
    public class RegexExtractor : IFieldExtractor
    {
        public IEnumerable<string> GetValue(string text, IDictionary<string, string> options)
        {
            if (options == null) throw new ArgumentNullException("options");
            if (!options.ContainsKey("pattern")) throw new ArgumentNullException("pattern is required", "options");
            var pattern = options["pattern"];
            return Regex.Matches(text, pattern, GetRegexOptions(options))
                .Cast<Match>()
                .Where(i => i.Success)
                .Select(i => i.Value);
        }

        protected virtual RegexOptions GetRegexOptions(IDictionary<string, string> options)
        {
            var result = RegexOptions.IgnoreCase;
            if (!options.ContainsKey("options")) return result;
            if(!Enum.TryParse<RegexOptions>(options["options"], out result)) throw new ArgumentOutOfRangeException(string.Format("RegexOptions does not support value {0} as part of the enums", options["options"]), "options");
            return result;
        }
    }
}
