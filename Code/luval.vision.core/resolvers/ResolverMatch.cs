using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class ResolverMatch
    {
        public string Text { get; set; }
        public int Index { get; set; }
        public int Length { get; set; }

        public static ResolverMatch Load(Match item)
        {
            return new ResolverMatch() { Text = item.Value, Index = item.Index, Length = item.Length };
        }
    }
}
