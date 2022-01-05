using Microsoft.Recognizers.Text.Sequence;
using System;
using System.Collections.Generic;
using System.Text;

namespace luval.vision.core.extractors
{
    public class EmailExtractor : MicrosoftRecognizerExtractor
    {
        public EmailExtractor() : base((query, culture) => SequenceRecognizer.RecognizeEmail(query?.ToLowerInvariant(), culture))
        {
        }
    }
}
