using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class StringUtils
    {
        public static IEnumerable<Match> GetWords(string text)
        {
            return Regex.Matches(text, @"(\b[^\s]+\b)").Cast<Match>().Where(i => i.Success).ToList();
        }

        public static string RemoveMultipleSpaces(string text)
        {
            var options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(text, " ");
        }

        public static IEnumerable<string> GetWordsSimple(string text)
        {
            return RemoveMultipleSpaces(text).Split(" ".ToCharArray());
        }

        public static string SanatizeToLowerInvariant(string text)
        {
            return string.Join(" ", GetWords(text)).ToLowerInvariant();
        }

        public static int CalculateLevenshteinDistance(string a, string b)
        {
            if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b)) return 0;

            int lengthA = a.Length;
            int lengthB = b.Length;
            var distances = new int[lengthA + 1, lengthB + 1];
            for (int i = 0; i <= lengthA; distances[i, 0] = i++) ;
            for (int j = 0; j <= lengthB; distances[0, j] = j++) ;

            for (int i = 1; i <= lengthA; i++)
                for (int j = 1; j <= lengthB; j++)
                {
                    int cost = b[j - 1] == a[i - 1] ? 0 : 1;
                    distances[i, j] = Math.Min
                        (
                        Math.Min(distances[i - 1, j] + 1, distances[i, j - 1] + 1),
                        distances[i - 1, j - 1] + cost
                        );
                }
            return distances[lengthA, lengthB];
        }

        public static string CleanText(string text)
        {
            return string.Join(" ", GetWords(text).Select(i => i.Value.ToLowerInvariant().Replace(".", "").Replace(":", "")));
        }

        public static double RankSearch(string input, string pattern)
        {
            var i = CleanText(input).Replace(" ", "");
            var p = CleanText(pattern).Replace(" ", "");
            var tot = i.Length + p.Length;
            var res = CalculateLevenshteinDistance(i, p);
            if (res == 0) return 1d;
            return (double)res / (double)tot;
        }
    }
}
