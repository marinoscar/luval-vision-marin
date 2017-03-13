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
        public const string NumberRegEx = @"\b[0-9]{1,3}(,[0-9]{3})*(\.[0-9]+)?\b|\.[0-9]+\b";
        public const string DateRegEx = @"([1-9]{2}[\/\.\-][0-9]{2}[\/\.\-][0-9]{4})|([1-9]{4}[\/\.\-][0-9]{2}[\/\.\-][0-9]{4})|([1-9]{2}[\/\.\-][0-9]{2}[\/\.\-][0-9]{2})";

        public static bool IsNumber(OcrElement word)
        {
            var result = Regex.Matches(word.Text, NumberRegEx).Cast<Match>().Where(i => i.Success).FirstOrDefault();
            if (result == null) return false;
            var parseResult = 0d;
            return double.TryParse(result.Value, out parseResult);
        }

        public static bool IsDate(OcrElement word)
        {
            var result = Regex.Matches(word.Text, DateRegEx).Cast<Match>().Where(i => i.Success).FirstOrDefault();
            return result != null && result.Success;
        }

        public static void ClassifyWord(OcrWord word)
        {
            if (IsNumber(word)) word.DataType = DataType.Number;
            if (IsDate(word)) word.DataType = DataType.Date;
        }
    }
}
