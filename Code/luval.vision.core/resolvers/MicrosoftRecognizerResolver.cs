using Microsoft.Recognizers.Text;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace luval.vision.core.resolvers
{
    public abstract class MicrosoftRecognizerResolver : IStringResolver
    {
        Func<string, string, List<ModelResult>> _resolver;

        public MicrosoftRecognizerResolver(Func<string, string, List<ModelResult>> resolver)
        {
            if (resolver == null) throw new ArgumentNullException("resolver", "the function pointer cannot be null");
            _resolver = resolver;
        }

        public abstract string Code { get; }

        public string GetValue(string text)
        {
            var res = GetValues(text).FirstOrDefault();
            if (res == null) return null;
            return res.Text;
        }

        public IEnumerable<ResolverMatch> GetValues(string text)
        {
            return _resolver(text, "en-us").Select(i => new ResolverMatch() { 
                Text = i.Text, Length = i.Text.Length, Index = i.Start
            });
        }

        public bool IsMatch(string text)
        {
            return !string.IsNullOrWhiteSpace(GetValue(text));
        }
    }
}
