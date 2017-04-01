using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class WordResolver : IStringResolver
    {
        private const string _vowels = "aeiou";
        public string Code { get { return "word"; } }

        public string GetValue(string text)
        {
            return IsMatch(text) ? text : string.Empty;
        }

        public IEnumerable<ResolverMatch> GetValues(string text)
        {
            var res = new List<ResolverMatch>();
            var val = GetValue(text);
            if (string.IsNullOrWhiteSpace(val)) return res;
            res.Add(new ResolverMatch()
            {
                Text = val,
                Index = 0,
                Length = val.Length
            });
            return res;
        }

        public bool IsMatch(string text)
        {
            var hasAtLeastOneVowel = text.ToLowerInvariant().Any(i => _vowels.Contains(i));
            var noDigits = !text.Any(i => char.IsNumber(i));
            return hasAtLeastOneVowel && noDigits;
        }
    }
}
