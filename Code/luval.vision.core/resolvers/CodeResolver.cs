using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class CodeResolver : RegexResolver
    {
        private const string _exp = @"[0-9a-zA-Z\-_ ]*";
        private const string _nums = "0123456789";

        public CodeResolver() : base(_exp)
        {

        }

        public override string Code { get { return "code"; } }

        public override bool IsMatch(string text)
        {
            return base.IsMatch(text) && text.Any(i => char.IsDigit(i));
        }
    }
}
