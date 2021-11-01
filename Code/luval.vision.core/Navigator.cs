using luval.vision.core.resolvers;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public Navigator(ImageInfo info, OcrResult ocrResult, IEnumerable<AttributeMapping> mappings)
        {
            OcrResult = ocrResult;
            Elements = new List<OcrElement>(ocrResult.Lines);
            Mappings = new List<AttributeMapping>(mappings);
            ImageInfo = info;
            _resManager = new StringResolverManager();
        }
        public OcrResult OcrResult { get; set; }
        public List<OcrElement> Elements { get; set; }
        public List<AttributeMapping> Mappings { get; set; }
        public ImageInfo ImageInfo { get; set; }


        public IEnumerable<OcrRegexResult> Find(string pattern, IEnumerable<OcrElement> elements)
        {
            return elements.Where(i => !string.IsNullOrWhiteSpace(i.Text) && Regex.IsMatch(i.Text, pattern)).OrderBy(i => i.Location.Y).
                Select(i => new OcrRegexResult()
                {
                    RegExPattern = pattern,
                    Element = i,
                    Match = Regex.Match(i.Text, pattern)
                }); ;
        }

        public List<MappingResult> ExtractAttributes()
        {
            var result = new List<MappingResult>();
            foreach (var map in Mappings)
            {
                var elements = Elements;
                if (map.AreaSearch)
                {
                    var searchLoc = map.GetAreaSearch(OcrResult.Regions.First());
                    var words = OcrResult.Words
                        .Where(i => i.Location.X >= searchLoc.X && i.Location.X < searchLoc.XBound)
                        .Where(i => i.Location.Y >= searchLoc.Y && i.Location.Y < searchLoc.YBound).ToList();
                    elements = new List<OcrElement>(OcrLoaderHelper.GetLines(words, OcrResult.Regions.First(), ImageInfo));
                }
                ExtractAttributes(map, elements, result);
                if (!result.Any(i => i.Map == map)) result.Add(new MappingResult() { Map = map, Value = null });
            }
            return result;
        }

        private List<MappingResult> ExtractAttributes(AttributeMapping map, IEnumerable<OcrElement> elements, List<MappingResult> result)
        {
            if (map.AnchorPatterns == null)
            {
                var values = SearchValuePattern(map, elements).Select(i => new MappingResult()
                {
                    AnchorElement = null,
                    Location = i.element.Location,
                    Map = map,
                    ResultElement = i.element,
                    Value = GetResolver(i.pattern, i.element.Text).GetValue(i.element.Text)
                });
                var value = map.IsAttributeLast ? values.LastOrDefault() : values.FirstOrDefault();
                if(value != null)
                    result.Add(value);
                return result;
            }
            var found = false;
            foreach (var pattern in map.AnchorPatterns)
            {
                if (found) continue;
                var anchorElement = Find(pattern, elements);
                if (anchorElement == null || !anchorElement.Any()) continue;
                var sortedAnchorEl = new List<OcrRegexResult>();

                if (map.AttributeIndex == null)
                    sortedAnchorEl = map.IsAttributeLast ? anchorElement.Reverse().ToList() : anchorElement.ToList();
                else if (anchorElement.Count() > map.AttributeIndex.Value)
                    sortedAnchorEl.Add(anchorElement.ToArray()[map.AttributeIndex.Value]);

                var isDown = false;
                foreach (var sortedAnchorItem in sortedAnchorEl)
                {
                    switch (map.ValueDirection)
                    {
                        case Direction.Down:
                            isDown = true;
                            found = AcceptSearch(map, result, sortedAnchorItem, SearchDown(sortedAnchorItem.Element, map, elements), isDown);
                            break;
                        case Direction.Right:
                            found = AcceptSearch(map, result, sortedAnchorItem, SearchRight(sortedAnchorItem.Element, map, elements), isDown);
                            break;
                        case Direction.Top:
                            found = AcceptSearch(map, result, sortedAnchorItem, SearchTop(sortedAnchorItem.Element, map, elements), isDown);
                            break;
                        default:
                            var vals = SearchRight(sortedAnchorItem.Element, map, elements);
                            if (vals == null || !vals.Any())
                            {
                                vals = SearchDown(sortedAnchorItem.Element, map, elements);
                                isDown = true;
                            }
                            found = AcceptSearch(map, result, sortedAnchorItem, vals, isDown);
                            break;
                    }
                    if (found) break;
                }
            }
            return result;
        }

        private IEnumerable<SearchResult> SearchTop(OcrElement anchor, AttributeMapping map, IEnumerable<OcrElement> elements)
        {
            var result = new List<SearchResult>();
            if (map.GetTopLine)
            {
                var lines = elements.Where(i => i.Location.Y < anchor.Location.Y).OrderByDescending(i => i.Location.Y).ToList();
                result.Add(new SearchResult() {  element = lines.FirstOrDefault(), pattern = map.ValuePatterns.FirstOrDefault(), success = true });
            }
            return result;
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

        private bool AcceptSearch(AttributeMapping map, List<MappingResult> items, OcrRegexResult anchor, IEnumerable<SearchResult> values, bool isDown)
        {
            if (values == null || !values.Any()) return false;
            var searchValue = map.IsValueLast ? values.LastOrDefault() : values.FirstOrDefault();
            var loc = GetMapLocation(anchor.Element, searchValue.element, isDown);
            var value = default(string);
            if (searchValue.success)
            {
                value = GetResolver(searchValue.pattern, searchValue.element.Text).GetValue(GetValueSearchableText(map, anchor, searchValue));
            }
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (anchor.Match.Success)
                value = value.Replace(anchor.Match.Value, ""); //Removes the anchor from the value
            var res = new MappingResult()
            {
                Map = map,
                Location = loc.Item1,
                RelativeLocation = loc.Item2,
                AnchorElement = anchor.Element,
                ResultElement = searchValue.element,
                Value = value
            };
            items.Add(res);
            return !string.IsNullOrWhiteSpace(searchValue.element.Text);
        }

        private string GetValueSearchableText(AttributeMapping map, OcrRegexResult anchorElement, SearchResult element)
        {
            if (!map.CleanLeft) return element.element.Text;
            if (anchorElement.Element.Code != element.element.Code) return element.element.Text;
            var startIndex = anchorElement.Match.Index + anchorElement.Match.Length;
            var lenght = anchorElement.Element.Text.Length - startIndex;
            if (lenght > 0)
                return anchorElement.Element.Text.Substring(startIndex, lenght);
            return element.element.Text;
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

        private IEnumerable<SearchResult> SearchDown(OcrElement reference, AttributeMapping map, IEnumerable<OcrElement> elements)
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
            var subset = elements.Where(i => i != reference && i.Location.Y > searchArea.Y && i.Location.YBound <= maxY && i.Location.X > minX && i.Location.XBound < maxX)
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
            return FilterByPattern(dataSet, map);
        }

        private IEnumerable<SearchResult> SearchValuePattern(AttributeMapping map, IEnumerable<OcrElement> elements)
        {
            var result = new List<SearchResult>();
            foreach (var pattern in map.ValuePatterns)
            {
                result.AddRange(elements.Where(i => GetResolver(pattern, i.Text).IsMatch(i.Text))
                .Select(i => new SearchResult()
                {
                    element = i,
                    pattern = map.ValuePatterns.First(),
                    success = true
                }));
            }
            return result;
        }

        private IEnumerable<SearchResult> SearchRight(OcrElement reference, AttributeMapping map, IEnumerable<OcrElement> elements)
        {
            //First we check in the same element for the valaue
            var sameElementRes = FilterByPattern(new OcrElement[] { reference }, map);
            if (sameElementRes != null && sameElementRes.Any()) return sameElementRes;
            var minX = reference.Location.XBound;
            var minY = reference.Location.Y - (reference.Location.Y * ErrorMargin);
            var maxY = reference.Location.YBound * (1 + ErrorMargin);
            var middleLine = (reference.Location.Y + (reference.Location.Height / 3));
            var dataSet = elements.Where(i => i.Location.X > minX &&
               i.Location.Y > minY &&
               i.Location.YBound < maxY)
               .ToList();
            return FilterByPattern(dataSet, map);
        }

        private IEnumerable<SearchResult> FilterByPattern(IEnumerable<OcrElement> elements, AttributeMapping map)
        {
            if (map == null || map.ValuePatterns == null || !map.ValuePatterns.Any()) return elements.Select(i => new SearchResult() { element = i });
            var result = new List<SearchResult>();
            foreach (var p in map.ValuePatterns)
            {
                result.AddRange(elements.Where(i => Resolve(p, i.Text)).Select(t => new SearchResult() { pattern = p, element = t, success = true }));
            }
            return result;
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

        private class SearchResult { public string pattern; public OcrElement element; public bool success; }
    }
}
