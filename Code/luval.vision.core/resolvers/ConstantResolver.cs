using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class ConstantResolver : IStringResolver
    {
        public string Code => "constant";

        public string GetValue(string text)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ResolverMatch> GetValues(string text)
        {
            throw new NotImplementedException();
        }

        public bool IsMatch(string text)
        {
            throw new NotImplementedException();
        }
    }
}
