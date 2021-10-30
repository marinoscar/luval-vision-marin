using Microsoft.Recognizers.Text.Number;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class NumberResolver : MicrosoftRecognizerResolver
    {
        public override string Code { get { return "number"; } }

        NumberResolver() : base((query, culture) => NumberRecognizer.RecognizeNumber(query, culture))
        {

        }
    }
}
