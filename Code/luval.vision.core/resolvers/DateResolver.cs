using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class DateResolver : RegexResolver
    {

        public DateResolver() : base(_exp)
        {

        }

        public const string _exp = @"[0-9]{2}[\/-][0-9]{2}[\/-][0-9]{4}|[0-9]{2}[\/-][0-9]{2}[\/-][0-9]{2}|[0-9]{4}[\/-][0-9]{2}[\/-][0-9]{2}";

        public override string Code { get { return "date"; } }
    }
}
