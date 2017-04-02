using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class NumberResolver : IStringResolver
    {
        public string Code { get { return "number"; } }

        public string GetValue(string text)
        {
            var res = GetValues(text).FirstOrDefault() ?? new ResolverMatch();
            return res.Text;
        }

        public IEnumerable<ResolverMatch> GetValues(string text)
        {
            return StringUtils.GetWords(text).Where(i => IsMatch(i.Value)).Select(i => ResolverMatch.Load(i)).ToList();
        }

        public bool IsMatch(string text)
        {
            return text.All(char.IsNumber);
        }
    }
}
