using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class RegexHelper
    {
        public static IEnumerable<Match> GetWords(string text)
        {
            return Regex.Matches(text, @"(\b[^\s]+\b)").Cast<Match>().Where(i => i.Success).ToList();
        }
    }
}
