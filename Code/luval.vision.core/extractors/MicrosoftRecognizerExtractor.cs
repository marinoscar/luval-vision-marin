using Microsoft.Recognizers.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core.extractors
{
    public abstract class MicrosoftRecognizerExtractor : IFieldExtractor
    {
        Func<string, string, List<ModelResult>> _recognizer;

        public MicrosoftRecognizerExtractor(Func<string, string, List<ModelResult>> recognizer)
        {
            if (recognizer == null) throw new ArgumentNullException("recognizer", "the function pointer cannot be null");
            _recognizer = recognizer;
        }

        public IEnumerable<string> GetValue(string text, IDictionary<string, string> options)
        {
            return _recognizer(text, GetCulture(options)).Select(i => i.Text);
        }

        protected virtual string GetCulture(IDictionary<string, string> option)
        {
            if (option != null && !option.ContainsKey("culture")) return "en-us";
            return option["culture"];
        }


    }
}
