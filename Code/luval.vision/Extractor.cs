﻿using luval.vision.core;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace luval.vision
{
    public class Extractor
    {

        ConfigOptions _configOptions;
        OcrRegion _region;
        ImageInfo _imageInfo;

        public Extractor(ConfigOptions options, OcrRegion region, ImageInfo imageInfo)
        {
            _configOptions = options;
            _region = region;
            _imageInfo = imageInfo;
        }

        public IEnumerable<ExtractionResult> GetValues()
        {
            var result = new List<ExtractionResult>();
            foreach (var option in _configOptions.Fields)
            {
                result.AddRange(GetValue(option));
            }
            return result;
        }

        private List<ExtractionResult> GetValue(FieldOption option)
        {
            var result = new List<ExtractionResult>();
            var area = GetArea(option);

            var lines = GetLinesFromArea(option.GetLineResolver(), option.GetLinerResolverOptions(),  area, _region.Words);
            if (option.FieldExtractor.UseAllArea) lines = GetSingleLine(lines);
            if (option.FieldAnchor == null)
                result.AddRange(ExtractValue(option, lines));
            else
                result.AddRange(ExtractValueFromAnchor(option, lines));
            return result;
        }

        private IEnumerable<ExtractionResult> ExtractValueFromAnchor(FieldOption option, IEnumerable<OcrElement> elements)
        {
            var items = new List<OcrElement>();

            foreach (var pattern in option.FieldAnchor.Patterns)
            {
                OcrElement element = null;
                var matchedLines = elements.Where(i => Regex.IsMatch(i.Text, pattern)).ToList();
                if (matchedLines.Any())
                {
                    if (option.FieldAnchor.ExpectedIndex > 0)
                    {
                        if (matchedLines.Count < option.FieldAnchor.ExpectedIndex)
                            throw new IndexOutOfRangeException(string.Format("Index provided {0} is out of range for field {1}",
                                option.FieldAnchor.ExpectedIndex, option.FieldName));
                        element = matchedLines[option.FieldAnchor.ExpectedIndex];
                    }
                    else if (option.FieldAnchor.UseLast)
                        element = matchedLines.Last();
                    else
                        element = matchedLines.First();
                    items.Add(element);
                }
            }
            if (!items.Any()) 
                return new[] { new ExtractionResult() { Option = option, Value = null } };
            return ExtractValue(option, items);
        }

        private IEnumerable<ExtractionResult> ExtractValue(FieldOption option, IEnumerable<OcrElement> elements)
        {
            var res = new List<ExtractionResult>();
            var extractor = option.FieldExtractor.Create();
            foreach (var element in elements)
            {
                var values = extractor.GetValue(element.Text, option.FieldExtractor.ExtractorOptions);
                foreach (var val in values)
                {
                    var text = val;
                    if(option.FieldExtractor.PostProcessing != null)
                    {
                        var post = option.FieldExtractor.PostProcessing.Create();
                        text = post.ProcessValue(val, option.FieldExtractor.PostProcessing.Options);
                    }
                    res.Add(new ExtractionResult() { Element = element, Value = text.TrimEx(), Option = option });
                }
            }
            if (option.FieldExtractor.ExpectedIndex > 0 && res.Any())
            {
                if (res.Count < option.FieldExtractor.ExpectedIndex)
                    throw new IndexOutOfRangeException(string.Format("Provided index for field {0} is out of range", option.FieldName));
                return new[] { new ExtractionResult() { Option = option, Value = res[option.FieldExtractor.ExpectedIndex].Value } };
            }
            //if there is no result we add a null value
            if (!res.Any())
                res.Add(new ExtractionResult() { Option = option, Value = null });
            else if (option.FieldExtractor.UseLast)
                return new[] { res.Last() };
            else
                return new[] { res.First() };
            
            //remove duplicate nulls
            if (res.Count > res.Count(i => string.IsNullOrWhiteSpace(i.Value))) 
                return res.Where(i => !string.IsNullOrWhiteSpace(i.Value)).ToList();

            return res;
        }

        private List<OcrLine> GetSingleLine(IEnumerable<OcrLine> lines)
        {
            var line = new OcrLine()
            {
                Id = 1,
                ParentRegion = lines.First().ParentRegion,
                Text = string.Join("\n", lines.Select(i => i.Text)),
                Words = lines.SelectMany(i => i.Words).ToList(),
                Location = new OcrLocation()
                {
                    X = lines.Min(i => i.Location.X),
                    Y = lines.Min(i => i.Location.Y),
                    Width = lines.Min(i => i.Location.XBound) - lines.Min(i => i.Location.X),
                    Height = lines.Min(i => i.Location.YBound) - lines.Min(i => i.Location.Y)
                }
            };
            return new List<OcrLine>(new[] { line });
        }

        private string GetTextFromLines(IEnumerable<OcrLine> lines)
        {
            var sw = new StringWriter();
            lines.ToList().ForEach(i => sw.WriteLine(i.Text));
            return sw.ToString();
        }

        private IEnumerable<OcrLine> GetLinesFromArea(IOcrLineResolver lineResolver, IDictionary<string, string> lineResolverOptions, OcrLocation area, IEnumerable<OcrWord> elements)
        {
            var items = elements.Where(i => i.Location.X >= area.X && i.Location.X < area.XBound)
                        .Where(i => i.Location.Y >= area.Y && i.Location.Y < area.YBound).ToList();
            return lineResolver.GetLines(items, lineResolverOptions);
        }

        private OcrLocation GetArea(FieldOption option)
        {
            if (option.SearchArea == null) return _imageInfo.ToLocation();
            return option.GetAreaSearch(_imageInfo.ToLocation());
        }
    }
}
