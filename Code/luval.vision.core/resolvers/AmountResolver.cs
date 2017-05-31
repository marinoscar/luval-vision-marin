using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class AmountResolver : RegexResolver
    {

        private const string _exp = @"(\b[0-9]{1,3}((,| |\.)[0-9]{3})*(\.[0-9]+)?\b|\.[0-9]+\b)|(\b[0-9]*\b)|(\b[0-9]*(\.|,| )[0-9]*\b)";
        private CultureInfo es;
        private CultureInfo en;

        public AmountResolver() : base(_exp)
        {
            es = CultureInfo.GetCultureInfo("es");
            en = CultureInfo.GetCultureInfo("en");
        }


        public override string Code { get { return "amount"; } }


        public override IEnumerable<ResolverMatch> GetValues(string text)
        {
            return base.GetValues(text).Where(i => i.Text.Any(HasValidChar));
        }

        public override string GetValue(string text)
        {
            if(text.Replace(".", "").Replace(",", "").Replace(" ", "").ToCharArray().All(char.IsNumber))
            {
                var t = text.Replace(" ", "");
                var res = false;
                var d = 0d;
                res = double.TryParse(t, NumberStyles.Any, en, out d);
                if (res) return d.ToString();
                res = double.TryParse(t, NumberStyles.Any, es, out d);
                if (res) return d.ToString();
            }
            return base.GetValue(text);
        }

        public override bool IsMatch(string text)
        {
            return base.IsMatch(text) && text.Any(HasValidChar) && text.Any(c => char.IsNumber(c));
        }

        private bool HasValidChar(char c)
        {
            return ".,".Contains(c);
        }
    }
}
