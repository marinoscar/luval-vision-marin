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

        public Navigator(ImageInfo info, IEnumerable<OcrElement> elements, IEnumerable<AttributeMapping> mappings)
        {
            Elements = new List<OcrElement>(elements);
            Mappings = new List<AttributeMapping>(mappings);
            ImageInfo = info;
            _resManager = new StringResolverManager();
        }
        public List<OcrElement> Elements { get; set; }
        public List<AttributeMapping> Mappings { get; set; }
        public ImageInfo ImageInfo { get; set; }

        public IEnumerable<OcrElement> FindByText(string text)
        {
            return Elements.Where(i => i.Text == text);
        }


        public IEnumerable<OcrElement> Find(string pattern)
        {
            return Elements.Where(i => !string.IsNullOrWhiteSpace(i.Text) && Resolve(pattern, i.Text)).OrderBy(i => i.Location.Y).ToList();
        }

        public List<MappingResult> ExtractAttributes()
        {
            var extractor = new EntityExtractor(new OcrResult()
            {
                Info = ImageInfo, Lines = Elements.Select(i => (OcrLine)i).ToList()
            }, Mappings);
            return extractor.DoExtract().ToList();
            //var result = new List<MappingResult>();
            //foreach (var map in Mappings)
            //{
            //    foreach (var pattern in map.AnchorPatterns)
            //    {
            //        if (string.IsNullOrWhiteSpace(pattern)) continue;
            //        var elements = Find(pattern);
            //        if (elements == null || !elements.Any()) continue;
            //        var sortedElements = map.IsAttributeLast ? elements.Reverse().ToList() : elements.ToList();
            //        var found = false;
            //        var isDown = false;
            //        foreach (var item in sortedElements)
            //        {
            //            switch (map.ValueDirection)
            //            {
            //                case Direction.Down:
            //                    isDown = true;
            //                    found = AcceptSearch(map, result, item, SearchDown(item, map.ValuePatterns), isDown);
            //                    break;
            //                case Direction.Right:
            //                    found = AcceptSearch(map, result, item, SearchRight(item, map.ValuePatterns), isDown);
            //                    break;
            //                default:
            //                    var vals = SearchRight(item, map.ValuePatterns);
            //                    if (vals == null || !vals.Any())
            //                    {
            //                        vals = SearchDown(item, map.ValuePatterns);
            //                        isDown = true;
            //                    }
            //                    found = AcceptSearch(map, result, item, vals, isDown);
            //                    break;
            //            }
            //            if (found) break;
            //        }
            //        break;
            //    }
            //}
            //return result;
        }

        public void DoExtract()
        {
            foreach (var map in Mappings)
            {
                foreach (var pattern in map.ValuePatterns)
                {
                    if (string.IsNullOrWhiteSpace(pattern)) continue;
                    var elements = Find(pattern);
                    if (elements == null || !elements.Any()) continue;
                    foreach (var el in elements)
                    {
                        var upRes = SearchUp(el, map.AnchorPatterns);
                    }
                }
            }
        }



        public static IEnumerable<OcrLine> GetWordsHorizontallyAligned(IEnumerable<OcrWord> elements, float horizontalErrorMargin)
        {
            var lines = new List<OcrLine>();
            var sorted = elements.OrderBy(i => i.Location.Y).ThenBy(i => i.Location.X).ToList();
            var id = 1;
            while (sorted.Count > 0)
            {
                var item = sorted.First();
                var minY = (int)(item.Location.Y - (item.Location.Y * horizontalErrorMargin));
                var maxY = (int)(item.Location.Y + (item.Location.Y * horizontalErrorMargin));
                var wordsInLine = sorted.Where(i => (i.Id != item.Id) && (i.Location.Y >= minY && i.Location.Y <= maxY)).OrderBy(i => i.Location.X).ToList();
                wordsInLine.Insert(0, item);
                lines.Add(new OcrLine()
                {
                    Id = id,
                    Words = wordsInLine.OrderBy(i => i.Location.X).ToList(),
                    Location = GetLineLocation(wordsInLine)
                });
                wordsInLine.ForEach(i => sorted.Remove(i));
            }
            return lines;
        }

        private static OcrLocation GetLineLocation(IEnumerable<OcrElement> items)
        {
            var x = items.Min(i => i.Location.X);
            var y = items.Min(i => i.Location.Y);
            var h = items.Max(i => i.Location.YBound) - x;
            var w = items.Max(i => i.Location.XBound) - y;
            return new OcrLocation() { X = x, Y = y, Height = h, Width = w };
        }

        private bool AcceptSearch(AttributeMapping map, List<MappingResult> items, OcrElement anchor, IEnumerable<SearchResult> values, bool isDown)
        {
            if (values == null || !values.Any()) return false;
            var val = map.IsValueLast ? values.LastOrDefault() : values.FirstOrDefault();
            var loc = GetMapLocation(anchor, val.element, isDown);
            var value = default(string);
            if (val.success)
            {
                value = GetResolver(val.pattern, val.element.Text).GetValue(val.element.Text);
            }
            var res = new MappingResult()
            {
                Map = map,
                Location = loc.Item1,
                RelativeLocation = loc.Item2,
                AnchorElement = anchor,
                ResultElement = val.element,
                Value = value
            };
            items.Add(res);
            return !string.IsNullOrWhiteSpace(val.element.Text);
        }

        private Tuple<OcrLocation, OcrRelativeLocation> GetMapLocation(OcrElement anchor, OcrElement value, bool isDown)
        {

            var res = new OcrLocation()
            {
                X = anchor.Location.X < value.Location.X ? anchor.Location.X : value.Location.X,
                Y = anchor.Location.Y < value.Location.Y ? anchor.Location.Y : value.Location.Y,
            };
            if (isDown)
            {
                res.Height = value.Location.YBound - res.Y;
                res.Width = anchor.Location.Width > value.Location.Width ? anchor.Location.Width : value.Location.Width;
            }
            else
            {
                var maxX = anchor.Location.XBound > value.Location.XBound ? anchor.Location.XBound : value.Location.XBound;
                res.Width = maxX - res.X;
                res.Height = anchor.Location.Height > value.Location.Height ? anchor.Location.Height : value.Location.Height;
            }
            var rel = OcrRelativeLocation.Load(res, ImageInfo);
            return new Tuple<OcrLocation, OcrRelativeLocation>(res, rel);
        }

        private IEnumerable<SearchResult> SearchDown(OcrElement reference, IEnumerable<string> patterns)
        {
            var dataSet = new List<OcrElement>();
            var searchArea = new OcrLocation()
            {
                X = reference.Location.X,
                Y = reference.Location.YBound,
                Width = reference.Location.Width,
                Height = reference.Location.Height
            };
            var maxY = reference.Location.YBound + (reference.Location.Height * 5);
            var minX = reference.Location.X - (reference.Location.Width * 4);
            var maxX = reference.Location.XBound + (reference.Location.Width * 4);
            var subset = Elements.Where(i => i != reference && i.Location.Y > searchArea.Y && i.Location.YBound <= maxY && i.Location.X > minX && i.Location.XBound < maxX)
                .OrderBy(i => i.Location.Y).ToList();
            var under = subset.Where(i => i != reference && i.Location.X >= searchArea.X && (i.Location.X < (searchArea.X + searchArea.Width)))
                .OrderBy(i => i.Location.Y).ToList();
            dataSet.AddRange(under);
            var ulMaxX = reference.Location.XBound * (1 + ErrorMargin);
            var underLeft = subset.Where(i => i.Location.X <= ulMaxX).OrderByDescending(i => i.Location.X).ToList();
            dataSet.AddRange(underLeft);
            var urMaxX = reference.Location.X;
            var underRight = subset.Where(i => i.Location.X >= urMaxX).OrderBy(i => i.Location.X).ToList();
            dataSet.AddRange(underRight);
            return FilterByPattern(dataSet, patterns);
        }

        private IEnumerable<SearchResult> SearchUp(OcrElement reference, IEnumerable<string> patterns)
        {
            var dataSet = new List<OcrElement>();
            var searchArea = new OcrLocation()
            {
                X = reference.Location.X,
                Y = reference.Location.Y, //Changed
                Width = reference.Location.Width,
                Height = reference.Location.Height
            };
            //Changed
            var minY = reference.Location.Y - (reference.Location.Height * 5);
            //Same
            var minX = reference.Location.X - (reference.Location.Width * 4);
            var maxX = reference.Location.XBound + (reference.Location.Width * 4);

            //Changed
            var subset = Elements.Where(i => i != reference && i.Location.Y < searchArea.Y && i.Location.YBound >= minY && i.Location.X > minX && i.Location.XBound < maxX)
                .OrderByDescending(i => i.Location.Y).ThenByDescending(i => i.Location.X).ToList();

            var newList = subset.Select(i => new t { Element = i, XOffset = (reference.Location.X - i.Location.X), YOffset = (reference.Location.Y - i.Location.YBound) })
                .ToList();
            var ordered = newList.OrderBy(i => i.YOffset).ThenBy(i => i.XOffset).ToList();
            var res = FilterByPattern(ordered.Select(i => i.Element).ToList(), patterns);
            return res;
        }

        private class t { public OcrElement Element; public double YOffset; public double XOffset; }

        private IEnumerable<SearchResult> SearchRight(OcrElement reference, IEnumerable<string> valuePatterns)
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

        private IEnumerable<SearchResult> FilterByPattern(IEnumerable<OcrElement> elements, IEnumerable<string> patterns)
        {
            if (patterns == null || !patterns.Any()) return elements.Select(i => new SearchResult() { element = i });
            var result = new List<SearchResult>();
            foreach (var p in patterns)
            {
                result.AddRange(elements.Where(i => !string.IsNullOrWhiteSpace(i.Text) && Resolve(p, i.Text)).Select(t => new SearchResult() { pattern = p, element = t, success = true }));
            }
            return result.Distinct().ToList();
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

        private class SearchResult { public string pattern; public OcrElement element; public bool success; public double YOffset; public double XOffset; }
    }
}
