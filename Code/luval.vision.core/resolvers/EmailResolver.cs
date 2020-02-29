using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class EmailResolver : RegexResolver
    {
        private const string _exp = @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}\b";

        public EmailResolver() : base(_exp)
        {
        }

        public override string Code => "email";
    }
}
