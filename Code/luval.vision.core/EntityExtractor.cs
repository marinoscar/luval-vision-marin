using luval.vision.core.resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class EntityExtractor
    {

        private const double ErrorMargin = 0.015d;
        private StringResolverManager _resManager;

        public EntityExtractor(OcrResult ocrResult, IEnumerable<AttributeMapping> mappings)
        {
            Info = ocrResult.Info;
            Elements = ocrResult.Lines;
            Mappings = new List<AttributeMapping>(mappings);
            OcrResult = ocrResult;
            _resManager = new StringResolverManager();
        }

        public OcrResult OcrResult { get; private set; }
        public ImageInfo Info { get; private set; }
        public List<OcrLine> Elements { get; private set; }
        public List<AttributeMapping> Mappings { get; private set; }

        public IEnumerable<MappingResult> DoExtract()
        {
            var result = new List<MappingResult>();
            foreach (var map in Mappings)
            {
                foreach (var pattern in map.ValuePatterns)
                {
                    if (string.IsNullOrWhiteSpace(pattern)) continue;
                    var elements = Find(pattern);
                    if (elements == null || !elements.Any()) continue;
                    foreach (var el in elements)
                    {
                        var upRes = SearchUp(map, el);
                    }
                }
            }
            return result;
        }

        public IEnumerable<OcrElement> Find(string pattern)
        {
            return Elements.Where(i => !string.IsNullOrWhiteSpace(i.Text) && Resolve(pattern, i.Text)).OrderBy(i => i.Location.Y).ToList();
        }

        private IEnumerable<MappingResult> SearchUp(AttributeMapping map, OcrElement reference)
        {
            var minY = reference.Location.Y - (reference.Location.Height * 5);
            var minX = reference.Location.X - (reference.Location.Width * 4);
            var maxX = reference.Location.XBound + (reference.Location.Width * 4);
            var subset = Elements.Where(i => i != reference && i.Location.Y < reference.Location.Y && i.Location.YBound >= minY && i.Location.X > minX && i.Location.XBound < maxX)
                .OrderByDescending(i => i.Location.Y).ThenByDescending(i => i.Location.X).ToList();
            return FilterByPattern(map, reference, subset);
        }

        private IEnumerable<MappingResult> FilterByPattern(AttributeMapping map, OcrElement valueElement,  IEnumerable<OcrLine> elements)
        {
            var patterns = map.AnchorPatterns;
            if (patterns == null || !patterns.Any()) return elements.Select(i => new MappingResult() { AnchorElement = valueElement, ResultElement = i });
            var result = new List<MappingResult>();
            foreach (var p in patterns)
            {
                var items = elements.Where(i => Resolve(p, i.Text)).Select(i => MappingResult.Create(Info, map, i, valueElement)).ToList();
                foreach(var item in items)
                {
                    if (!result.Select(i => i.AnchorElement.Id).Contains(item.AnchorElement.Id))
                        result.Add(item);
                }
            }
            //Sort by proximity to the anchor
            return result.OrderBy(i => i.OffsetY).ThenBy(i => i.OffsetX).ToList();
        }

        private bool Resolve(string pattern, string text)
        {
            return GetResolver(pattern, text).IsMatch(text);
        }

        private IStringResolver GetResolver(string pattern, string text)
        {
            if (pattern.StartsWith("@"))
            {
                var res = _resManager.GetByCode(pattern.Replace("@", ""));
                if (res != null) return res;
            }
            return new RegexResolver(pattern);
        }


    }
}
