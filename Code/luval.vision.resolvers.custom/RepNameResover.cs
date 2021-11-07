using luval.vision.core;
using luval.vision.core.extractors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace luval.vision.resolvers.custom
{
    public class RepNameResover : IFieldExtractor
    {

        public IEnumerable<string> GetValue(string text, IDictionary<string, string> options)
        {
            return new[] { FindValue(text) };
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
            foreach (var criteria in GetTopCriteria())
            {
                var topLine = lines.Where(i => i.ToLowerInvariant().StartsWith(criteria)).LastOrDefault();
                if (!string.IsNullOrWhiteSpace(topLine)) return topLine;
            }
            return null;
        }

        private string[] GetTopCriteria()
        {
            return new[] {
                "including sales tax", "property upon", "amount total"
            };
        }
    }
}
