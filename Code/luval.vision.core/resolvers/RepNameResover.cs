using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core.resolvers
{
    public class RepNameResover : IStringResolver
    {
        public string Code => "@repname";

        public string GetValue(string text)
        {
            return FindValue(text);
        }

        public IEnumerable<ResolverMatch> GetValues(string text)
        {
            var content = FindValue(text);
            if (string.IsNullOrWhiteSpace(content)) return new List<ResolverMatch>();
            return new[] { new ResolverMatch() {
                Index = 0, Length = content.Length, Text = content
            } };
        }

        public bool IsMatch(string text)
        {
            var content = FindValue(text);
            if (string.IsNullOrWhiteSpace(content)) return false;
            return GetLines(FindValue(text)).Count == 1;
        }


        private List<string> GetLines(string text)
        {
            return text.Split("\n".ToCharArray()).ToList();
        }
        private string FindValue(string text)
        {
            var lines = GetLines(text);
            TrimBottom(lines);
            TrimTop(lines);
            var content = TrimContent(string.Join(" ", lines));
            return content;
        }

        private string TrimContent(string content)
        {
            content = content.Replace("Accepted By:", "");
            content = content.Replace("Accepted by:", "");
            content = content.Replace("Accepted by", "");
            content = content.Replace("Accepted By", "");
            content = content.Replace("Sales Representative Name", "");
            content = content.Replace("Sales Representative", "");
            content = content.Replace("Representative", "");
            return content;
        }

        private void TrimBottom(List<string> lines)
        {
            var bottomLine = lines.Where(i => i.ToLowerInvariant().StartsWith("additional notices to customer".ToLowerInvariant())).LastOrDefault();
            if (string.IsNullOrWhiteSpace(bottomLine)) return;
            var bottomLineIdx = lines.IndexOf(bottomLine);
            lines.RemoveRange(bottomLineIdx, lines.Count - bottomLineIdx);
        }

        private void TrimTop(List<string> lines)
        {
            var topLine = GetTopAchorLine(lines);
            if (string.IsNullOrWhiteSpace(topLine)) return;
            var topLineIdx = lines.IndexOf(topLine);
            lines.RemoveRange(0, topLineIdx);
        }

        private string GetTopAchorLine(List<string> lines)
        {
            var criteria1 = "including sales tax, in full as indicated".ToLowerInvariant();
            var criteria2 = "property upon payment of the purchase amount".ToLowerInvariant();
            var topLine = lines.Where(i => i.ToLowerInvariant().StartsWith(criteria1)).LastOrDefault();
            if(string.IsNullOrWhiteSpace(topLine))
                topLine = lines.Where(i => i.ToLowerInvariant().StartsWith(criteria2)).LastOrDefault();
            if (string.IsNullOrWhiteSpace(topLine)) return null;
            return topLine;
        }
    }
}
