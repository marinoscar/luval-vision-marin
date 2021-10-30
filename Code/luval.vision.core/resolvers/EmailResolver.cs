using Microsoft.Recognizers.Text.Sequence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class EmailResolver : MicrosoftRecognizerResolver
    {
        public EmailResolver() : base((query, culture) => SequenceRecognizer.RecognizeEmail(query, culture))
        {
        }

        public override string Code => "email";
    }
}
