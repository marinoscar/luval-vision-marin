using Microsoft.Recognizers.Text.DateTime;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core.extractors
{
    public class DateExtractor : MicrosoftRecognizerExtractor
    {
        public DateExtractor() : base((query, culture) => DateTimeRecognizer.RecognizeDateTime(query, culture))
        {
        }
    }
}
