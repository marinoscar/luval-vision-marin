using luval.vision.core;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.resolvers.custom
{
    public class NumberPostProcessing : IFieldExtractorPostProcessing
    {
        public string ProcessValue(string text, IDictionary<string, string> options)
        {
            if (options == null || options.Count <= 0) throw new ArgumentNullException("options");
            if (string.IsNullOrWhiteSpace(text)) return text;
            text = CheckMinDigitCount(text, options);
            return text;
        }

        private string CheckMinDigitCount(string text, IDictionary<string, string> options)
        {
            if (!options.ContainsKey("MinDigitCount")) return text;
            var d = 0d;
            var res = double.TryParse(text, out d);
            if (!res) return null;
            if (text.Length < Convert.ToInt32(options["MinDigitCount"])) return null;
            return text;

        }
    }
}
