using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity.Resolvers
{
    public class NumberResolver : RegexResolver
    {

        private const string _exp = @"(\b[0-9]{1,3}(,[0-9]{3})*(\.[0-9]+)?\b|\.[0-9]+\b)|(\b[0-9]*\b)|(\b[0-9]*\.[0-9]*\b)";

        public NumberResolver() : base(_exp)
        {
        }


        public override string Code { get { return "number"; } }
    }
}
