using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class RegexResolver : IStringResolver
    {

        public RegexResolver(string pattern)
        {
            Pattern = pattern;
        }

        public virtual string Code { get { return "regex"; } }

        protected virtual string Pattern { get; private set; }

        public virtual string GetValue(string text)
        {
            var val = GetValues(text).FirstOrDefault() ?? new ResolverMatch();
            return val.Text;
        }

        public virtual IEnumerable<ResolverMatch> GetValues(string text)
        {
            var vals = Regex.Matches(text, Pattern).Cast<Match>().Where(i => i.Success && !string.IsNullOrWhiteSpace(i.Value));
            return vals.Select(i => ResolverMatch.Load(i)).ToList();
        }

        public virtual bool IsMatch(string text)
        {
            return Regex.IsMatch(text, Pattern);
        }
    }
}
