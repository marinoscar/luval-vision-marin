using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core.extractors
{
    public class NumberExtractor : MicrosoftRecognizerExtractor
    {
        public NumberExtractor() : base((query, culture) => DoNumber(query, culture))
        {
        }

        private static List<ModelResult> DoNumber(string query, string culture)
        {
            return NumberRecognizer.RecognizeNumber(query, culture).Where(i => i.Text.IsNumericValue()).ToList();
        }
    }
}
