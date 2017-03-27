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
            return Elements.Where(i => Regex.IsMatch(i.Text, pattern)).OrderBy(i => i.Location.Y).ToList();
        }

        public List<MappingResult> ExtractAttributes()
        {
            var result = new List<MappingResult>();
            foreach (var map in Mappings)
            {
                foreach (var pattern in map.AnchorPatterns)
                {
                    if (string.IsNullOrWhiteSpace(pattern)) continue;
                    var elements = Find(pattern);
                    if (elements == null || !elements.Any()) continue;
                    var sortedElements = map.IsAttributeLast ? elements.Reverse().ToList() : elements.ToList();
                    var found = false;
                    var isDown = false;
                    foreach (var item in sortedElements)
                    {
                        switch (map.ValueDirection)
                        {
                            case Direction.Down:
                                isDown = true;
                                found = AcceptSearch(map, result, SearchDown(item, map.ValuePatterns));
                                break;
                            case Direction.Right:
                                found = AcceptSearch(map, result, SearchRight(item, map.ValuePatterns));
                                break;
                            default:
                                var vals = SearchRight(item, map.ValuePatterns);
                                if (vals == null || !vals.Any())
                                {
                                    vals = SearchDown(item, map.ValuePatterns);
                                    isDown = true;
                                }
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

        private bool AcceptSearch(AttributeMapping map, List<MappingResult> items, OcrElement anchor, IEnumerable<OcrElement> values, bool isDown)
        {
            if (values == null || !values.Any()) return false;
            var val = map.IsValueLast ? values.LastOrDefault() : values.FirstOrDefault();
            var loc = GetMapLocation(anchor, val, isDown);
            var res = new MappingResult()
            {
                Map = map,
                Location = loc.Item1, RelativeLocation = loc.Item2,
                AnchorElement = anchor, ResultElement = val
            };
            items.Add(res);
            return !string.IsNullOrWhiteSpace(val.Text);
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
