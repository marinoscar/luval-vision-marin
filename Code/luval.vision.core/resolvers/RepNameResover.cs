using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace luval.vision.core.resolvers
{
    public class RepNameResover : IStringResolver
    {
        public string Code => "repname";

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
            if (!TrimBottom(lines)) return null;
            if (!TrimTop(lines)) return null;
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
            content = content.Replace("Ассepted", "");
            content = content.Replace("By", "");
            content = content.Replace("by", "");
            content = content.Replace(":", "");
            content = content.Replace(".", "");
            content = content.Replace("Sales", "");
            content = content.Replace("Name", "");
            return content.Trim();
        }

        private bool TrimBottom(List<string> lines)
        {
            var bottomLine = lines.Where(i => i.ToLowerInvariant().StartsWith("additional".ToLowerInvariant())).LastOrDefault();
            if (string.IsNullOrWhiteSpace(bottomLine)) return false;
            var bottomLineIdx = lines.IndexOf(bottomLine);
            lines.RemoveRange(bottomLineIdx, lines.Count - bottomLineIdx);
            return true;
        }

        private bool TrimTop(List<string> lines)
        {
            var topLine = GetTopAchorLine(lines);
            if (string.IsNullOrWhiteSpace(topLine)) return false;
            var topLineIdx = lines.IndexOf(topLine);
            lines.RemoveRange(0, topLineIdx + 1);
            return true;
        }

        private string GetTopAchorLine(List<string> lines)
        {
            var criteria1 = "including sales tax".ToLowerInvariant();
            var criteria2 = "property upon".ToLowerInvariant();
            var topLine = lines.Where(i => i.ToLowerInvariant().StartsWith(criteria1)).LastOrDefault();
            if (string.IsNullOrWhiteSpace(topLine))
                topLine = lines.Where(i => i.ToLowerInvariant().StartsWith(criteria2)).LastOrDefault();
            if (string.IsNullOrWhiteSpace(topLine)) return null;
            return topLine;
        }

        public static bool FindRepName(AttributeMapping map, IEnumerable<OcrLine> lines, List<MappingResult> result)
        {
            if (!map.ValuePatterns.Contains("@repname")) return false;
            var text = string.Join("\n", lines.Select(i => i.Text));
            var resolver = new RepNameResover();
            var res = resolver.GetValue(text);
            if (string.IsNullOrWhiteSpace(res)) return false;
            result.Add(new MappingResult()
            {
                Location = lines.First().Location,
                Map = map,
                ResultElement = lines.First(),
                Value = res
            });
            return true;
        }
    }
}
