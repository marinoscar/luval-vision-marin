using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class EntityExtractor
    {
        
        public static bool IsNumber(OcrElement word)
        {
            var result = Regex.Matches(word.Text, RegexTypes.I.GetExpression("number")).Cast<Match>().Where(i => i.Success).FirstOrDefault();
            if (result == null) return false;
            var parseResult = 0d;
            return double.TryParse(result.Value, out parseResult);
        }

        public static bool IsDate(OcrElement word)
        {
            var result = Regex.Matches(word.Text, RegexTypes.I.GetExpression("date")).Cast<Match>().Where(i => i.Success).FirstOrDefault();
            return result != null && result.Success;
        }

        public static void ClassifyWord(OcrWord word)
        {
            if (IsNumber(word)) word.DataType = DataType.Number;
            if (IsDate(word)) word.DataType = DataType.Date;
        }
    }
}
