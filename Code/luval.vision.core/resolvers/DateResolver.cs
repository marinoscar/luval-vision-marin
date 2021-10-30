using Microsoft.Recognizers.Text;
using Microsoft.Recognizers.Text.DateTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class DateResolver : MicrosoftRecognizerResolver
    {

        public DateResolver() : base((query, culture) => DateTimeRecognizer.RecognizeDateTime(query, culture))
        {

        }

        public override string Code { get { return "date"; } }

    }
}
