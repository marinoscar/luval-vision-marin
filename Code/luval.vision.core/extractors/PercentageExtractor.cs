using Microsoft.Recognizers.Text.Number;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core.extractors
{
    public class PercentageExtractor : MicrosoftRecognizerExtractor
    {
        public PercentageExtractor() : base((query, culture) => NumberRecognizer.RecognizePercentage(query, culture))
        {
        }
    }
}
