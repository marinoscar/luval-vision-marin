using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core.resolvers
{
    public class WordResolver : IStringResolver
    {
        public string Code { get { return "word"; } }

        public string GetValue(string text)
        {
            return IsMatch(text) ? text : string.Empty;
        }

        public bool IsMatch(string text)
        {
            return WordDictionary.I.IsInDictionary(Language.English, text);
        }
    }
}
