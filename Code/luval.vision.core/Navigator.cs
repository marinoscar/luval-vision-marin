using luval.vision.core.resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class Navigator
    {

        private const double ErrorMargin = 0.015d;
        private StringResolverManager _resManager;

        public Navigator(IEnumerable<OcrElement> elements, IEnumerable<AttributeMapping> mappings)
        {
            Elements = new List<OcrElement>(elements);
            Mappings = new List<AttributeMapping>(mappings);
            _resManager = new StringResolverManager();
        }
        public List<OcrElement> Elements { get; set; }
        public List<AttributeMapping> Mappings { get; set; }

        public IEnumerable<OcrElement> FindByText(string text)
        {
            return Elements.Where(i => i.Text == text);
        }


        public IEnumerable<OcrElement> Find(string pattern)
        {
            return Elements.Where(i => Regex.IsMatch(i.Text, pattern)).OrderBy(i => i.Location.Y).ToList();
        }

        public IDictionary<string, string> ExtractAttributes()
        {
            var result = new Dictionary<string, string>();
            foreach (var map in Mappings)
            {
                result[map.AttributeName] = null;
                foreach (var pattern in map.AnchorPatterns)
                {
                    if (string.IsNullOrWhiteSpace(pattern)) continue;
                    var elements = Find(pattern);
                    if (elements == null || !elements.Any()) continue;
                    var sortedElements = map.IsAttributeLast ? elements.Reverse().ToList() : elements.ToList();
                    var found = false;
                    foreach (var item in sortedElements)
                    {

                        switch (map.ValueDirection)
                        {
                            case Direction.Down:
                                found = AcceptSearch(map, result, SearchDown(item, map.ValuePatterns));
                                break;
                            case Direction.Right:
                                found = AcceptSearch(map, result, SearchRight(item, map.ValuePatterns));
                                break;
                            default:
                                var vals = SearchRight(item, map.ValuePatterns);
                                if (vals == null || !vals.Any()) vals = SearchDown(item, map.ValuePatterns);
                                found = AcceptSearch(map, result, vals);
                                break;
                        }
                        if (found) break;
                    }
                    break;
                }
            }
            return result;
        }

        private bool AcceptSearch(AttributeMapping map, IDictionary<string, string> items, IEnumerable<OcrElement> values)
        {
            if (values == null || !values.Any()) return false;
            var val = map.IsValueLast ? values.LastOrDefault() : values.FirstOrDefault();
            items[map.AttributeName] = val.Text;
            return !string.IsNullOrWhiteSpace(val.Text);
        }

        private IEnumerable<OcrElement> SearchDown(OcrElement reference, IEnumerable<string> valuePatterns)
        {
            var dataSet = new List<OcrElement>();
            var searchArea = new OcrLocation()
            {
                X = reference.Location.X,
                Y = reference.Location.YBound,
                Width = reference.Location.Width,
                Height = reference.Location.Height
            };
            var under = Elements.Where(i => i != reference && i.Location.X >= searchArea.X && (i.Location.X < (searchArea.X + searchArea.Width)))
                .OrderBy(i => i.Location.Y);
            dataSet.AddRange(under);
            var maxY = reference.Location.YBound + (reference.Location.Height * 5);
            var subset = Elements.Where(i => i != reference && i.Location.YBound <= maxY).OrderBy(i => i.Location.Y);
            var ulMaxX = reference.Location.XBound * (1 + ErrorMargin);
            var underLeft = subset.Where(i => i.Location.X <= ulMaxX).OrderByDescending(i => i.Location.X);
            dataSet.AddRange(underLeft);
            var urMaxX = reference.Location.X;
            var underRight = subset.Where(i => i.Location.X >= urMaxX).OrderBy(i => i.Location.X);
            dataSet.AddRange(underRight);
            return FilterByPattern(dataSet, valuePatterns);
        }

        private IEnumerable<OcrElement> SearchRight(OcrElement reference, IEnumerable<string> valuePatterns)
        {
            var minX = reference.Location.XBound;
            var minY = reference.Location.Y - (reference.Location.Y * ErrorMargin);
            var maxY = reference.Location.YBound * (1 + ErrorMargin);
            var middleLine = (reference.Location.Y + (reference.Location.Height / 3));
            var dataSet = Elements.Where(i => i.Location.X > minX &&
               i.Location.Y > minY &&
               i.Location.YBound < maxY)
               .ToList();
            return FilterByPattern(dataSet, valuePatterns);
        }

        private IEnumerable<OcrElement> FilterByPattern(IEnumerable<OcrElement> elements, IEnumerable<string> patterns)
        {
            if (patterns == null || !patterns.Any()) return elements;
            var result = new List<OcrElement>();
            foreach (var p in patterns)
            {
                result.AddRange(elements.Where(i => Resolve(p, i.Text)).ToList());
            }
            return result;
        }

        private bool Resolve(string pattern, string text)
        {
            if (pattern.StartsWith("@"))
            {
                var res = _resManager.GetByCode(pattern.Replace("@", ""));
                if (res != null) return res.IsMatch(text);
            }
            var regEx = new RegexResolver(pattern);
            return regEx.IsMatch(text);
        }
    }
}
