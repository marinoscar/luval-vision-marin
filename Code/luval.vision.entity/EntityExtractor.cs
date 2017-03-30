using luval.vision.entity.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class EntityExtractor
    {
        private static StringResolverManager _resMngr;

        private static StringResolverManager ResolverManager
        {
            get
            {
                if (_resMngr == null) _resMngr = new StringResolverManager();
                return _resMngr;
            }
        }

        public static bool IsNumber(OcrElement word)
        {
            return ResolverManager.Get<NumberResolver>().IsMatch(word.Text);

        }

        public static bool IsDate(OcrElement word)
        {
            return ResolverManager.Get<DateResolver>().IsMatch(word.Text);
        }

        public static bool IsWord(OcrElement word)
        {
            //return WordDictionary.I.IsInDictionary(Language.English, word.Text);
            return false;
        }

        public static void ClassifyWord(OcrWord word)
        {
            if (IsNumber(word)) word.DataType = DataType.Number;
            if (IsDate(word)) word.DataType = DataType.Date;
            if (IsWord(word)) word.DataType = DataType.Word;

        }
    }
}
