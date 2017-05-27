using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class CodeResolver : IStringResolver
    {

        private AmountResolver _amount;
        private NumberResolver _number;

        public CodeResolver()
        {
            _amount = new AmountResolver();
        }

        public string Code { get { return "code"; } }

        public string GetValue(string text)
        {
            var res = GetValues(text).FirstOrDefault();
            return res != null ? res.Text : default(string);
        }

        public IEnumerable<ResolverMatch> GetValues(string text)
        {
            return GetWords(text).Where(i => IsValidWord(i.Value)).Select(i => ResolverMatch.Load(i));
        }

        public bool IsMatch(string text)
        {
            var words = GetWords(text).Select(i => i.Value).Where(IsValidWord);
            return words.Any();
        }


        private List<Match> GetWords(string text)
        {
            return StringUtils.GetWords(text).ToList();
        }


        private bool IsValidWord(string text)
        {
            var res = (text.All(IsValidChar) && text.Any(char.IsNumber) && text.Count(IsCodeChar) <= 2) && !_amount.IsMatch(text) && !_number.IsMatch(text);
            return res;
        }

        private bool IsValidChar(char c)
        {
            return char.IsNumber(c) || char.IsLetter(c) || IsCodeChar(c);
        }

        private bool IsCodeChar(char c)
        {
            return "-_.".ToCharArray().Contains(c);
        }
    }
}
