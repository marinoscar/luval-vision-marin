using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class RegexTypes
    {
        public RegexTypes()
        {
            _expressions = new Dictionary<string, string>();
            _expressions["date"] = @"([1-9]{2}[\/\.\-][0-9]{2}[\/\.\-][0-9]{4})|([1-9]{4}[\/\.\-][0-9]{2}[\/\.\-][0-9]{4})|([1-9]{2}[\/\.\-][0-9]{2}[\/\.\-][0-9]{2})";
            _expressions["number"] = @"\b[0-9]{1,3}(,[0-9]{3})*(\.[0-9]+)?\b|\.[0-9]+\b";
        }
        private Dictionary<string, string> _expressions;
        private static RegexTypes _i;

        public string this[string item]
        {
            get
            {
                var index = item.Replace("{", "").Replace("}", "").ToLower();
                return _expressions[index];
            }
        }

        public string GetExpression(string exp)
        {
            var res = this[exp];
            if (!string.IsNullOrWhiteSpace(res)) return res;
            return exp;
        }

        public static RegexTypes I
        {
            get
            {
                if (_i == null) _i = new RegexTypes();
                return _i;
            }
        }
    }
}
