using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class NumberResolver : IStringResolver
    {

        private DateResolver _date;
        private AmountResolver _amount;

        public NumberResolver()
        {
            _date = new DateResolver();
            _amount = new AmountResolver();
        }

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
            var nums = StringUtils.GetWords(text).Select(i => i.Value).Where(i => i.All(char.IsNumber)).ToList();
            return nums.Count > 0 && !_date.IsMatch(text) && !_amount.IsMatch(text);
        }
    }
}
