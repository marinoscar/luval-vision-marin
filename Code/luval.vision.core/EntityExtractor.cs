﻿using luval.vision.core.resolvers;
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
                var mapResult = new List<MappingResult>();
                foreach (var pattern in map.ValuePatterns)
                {
                    if (string.IsNullOrWhiteSpace(pattern)) continue;
                    var elements = Find(pattern);
                    if (elements == null || !elements.Any()) continue;
                    foreach (var el in elements)
                    {
                        var left = SearchLeft(map, el);
                        var item = default(MappingResult);
                        if (left.Any())
                        {
                            item = left.First();
                            item.IsAnchorOnLeft = true;
                        }
                        else
                        {
                            var up = SearchUp(map, el);
                            if (up.Any()) item = up.First();
                        }
                        if (item != null)
                        {
                            item.Value = GetResolver(pattern).GetValue(el.Text);
                            mapResult.Add(item);
                        }
                    }
                }

                if (mapResult.Any())
                {
                    //we add the closest item
                    result.Add(mapResult.OrderBy(i => i.OffsetX).ThenBy(i => i.OffsetY).First());
                }
            }
            return result;
        }

        public string GetElementValue(AttributeMapping map, OcrElement element)
        {
            foreach(var p in map.ValuePatterns)
            {
                var res = GetResolver(p);
                var val = res.GetValue(element.Text);
                if (!string.IsNullOrWhiteSpace(val)) return val;
            }
            return default(string);
        }

        private IEnumerable<OcrLine> Find(string pattern)
        {
            return Elements.Where(i => !string.IsNullOrWhiteSpace(i.Text) && Resolve(pattern, i.Text)).OrderBy(i => i.Location.Y).ToList();
        }

        private IEnumerable<MappingResult> SearchUp(AttributeMapping map, OcrElement reference)
        {
            var minY = reference.Location.Y - (reference.Location.Height * 5);
            var minX = reference.Location.X - (reference.Location.Width * 4);
            var maxX = reference.Location.XBound + (reference.Location.Width * 4);
            var subset = Elements.Where(i => i != reference && !string.IsNullOrWhiteSpace(i.Text) && IsValidAnchor(i.Text) && i.Location.Y < reference.Location.Y && i.Location.YBound >= minY && i.Location.X > minX && i.Location.XBound < maxX)
                .OrderByDescending(i => i.Location.Y).ThenByDescending(i => i.Location.X).ToList();
            return MarryToAnchor(map, reference, subset);
        }

        private IEnumerable<MappingResult> SearchLeft(AttributeMapping map, OcrLine valueElement)
        {
            var minX = valueElement.Location.X;
            var minY = valueElement.Location.Y - (valueElement.Location.Y * ErrorMargin);
            var maxY = valueElement.Location.YBound * (1 + ErrorMargin);
            var middleLine = (valueElement.Location.Y + (valueElement.Location.Height / 3));
            var dataSet = Elements.Where(i => !string.IsNullOrWhiteSpace(i.Text) && IsValidAnchor(i.Text) &&
               i.Location.X < minX &&
               i.Location.Y > minY &&
               i.Location.YBound < maxY)
               .ToList();
            //check the value as a potential option
            if(IsValidAnchor(valueElement.Text))
                dataSet.Insert(0, valueElement);
            return MarryToAnchor(map, valueElement, dataSet);
        }

        private bool IsValidAnchor(string text)
        {
            var biggerThan4Chars = text.Length >= 4;
            var isDifferentThanNumbers = !text.ToCharArray().All(char.IsNumber);
            return biggerThan4Chars && isDifferentThanNumbers;
        }

        private IEnumerable<MappingResult> MarryToAnchor(AttributeMapping map, OcrElement valueElement, IEnumerable<OcrLine> elements)
        {
            if (map.AnchorPatterns == null || !map.AnchorPatterns.Any())
                return elements.Select(i => new MappingResult() { AnchorElement = valueElement, ResultElement = i });

            var result = new List<MappingResult>();
            foreach (var p in map.AnchorPatterns)
            {
                var items = elements.Where(i => RankMatch(p, i.Text, map.AnchorBlackList) > 0.9d).Select(i => MappingResult.Create(Info, map, i, valueElement, null, RankMatch(p, i.Text, map.AnchorBlackList))).ToList();
                foreach (var item in items)
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
            var res = GetResolver(pattern).IsMatch(text);
            return res;
        }

        private double RankMatch(string pattern, string text, IEnumerable<string> blackList)
        {
            var p = StringUtils.CleanText(pattern);
            var t = StringUtils.CleanText(text);
            foreach (var bl in blackList.Select(StringUtils.CleanText))
            {
                if (t.Contains(bl)) return 0;
            }
            return StringUtils.RankSearch(t, p);
        }

        private IStringResolver GetResolver(string pattern)
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
