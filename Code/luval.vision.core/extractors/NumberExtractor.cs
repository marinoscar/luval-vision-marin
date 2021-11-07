using Microsoft.Recognizers.Text.Number;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core.extractors
{
    public class NumberExtractor : MicrosoftRecognizerExtractor
    {
        public NumberExtractor() : base((query, culture) => NumberRecognizer.RecognizeNumber(query, culture))
        {
        }
    }
}
