using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity.Resolvers
{
    public class DateResolver : RegexResolver
    {
        public DateResolver() : base(_exp)
        {

        }

        public const string _exp = @"([0-9]{1,2}[\/\-][0-9]{1,2}[\/\-][0-9]{2,4})|([0-9]{2,4}[\/\-][0-9]{1,2}[\/\-][0-9]{1,2})";

        public override string Code { get { return "date"; } }
    }
}
