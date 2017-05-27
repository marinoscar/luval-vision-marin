using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class AmountResolver : RegexResolver
    {

        private const string _exp = @"(\b[0-9]{1,3}(,[0-9]{3})*(\.[0-9]+)?\b|\.[0-9]+\b)|(\b[0-9]*\b)|(\b[0-9]*\.[0-9]*\b)";

        public AmountResolver() : base(_exp)
        {
        }


        public override string Code { get { return "amount"; } }


        public override IEnumerable<ResolverMatch> GetValues(string text)
        {
            return base.GetValues(text).Where(i => i.Text.Any(HasValidChar));
        }

        public override bool IsMatch(string text)
        {
            return base.IsMatch(text) && text.Any(HasValidChar) && text.Any(c => char.IsNumber(c));
        }

        private bool HasValidChar(char c)
        {
            return ".,".Contains(c);
        }
    }
}
