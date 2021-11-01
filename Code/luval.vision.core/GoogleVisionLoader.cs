﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class GoogleVisionLoader : IVisionResultParser
    {

        public OcrResult DoParse(string jsonResult, ImageInfo info)
        {
            var words = new List<OcrWord>();
            var json = JObject.Parse(jsonResult);
            var lang = default(string);
            var result = new OcrResult() { Info = info, TextAngle = 0 };
            var mainRegion = new OcrRegion()
            {
                Id = 1,
                Code = OcrLoaderHelper.GetRegionCode(1)
            };
            var annotations = json["responses"].Value<JArray>()[0]["textAnnotations"].Value<JArray>();
            var wordId = 1;
            foreach (var ann in annotations)
            {
                if (string.IsNullOrWhiteSpace(lang)) lang = ann["locale"].Value<string>();
                if (wordId != 1)
                {
                    var word = new OcrWord()
                    {
                        Id = wordId,
                        Location = GetLocation(ann, info),
                        Text = ann["description"].Value<string>()
                    };
                    words.Add(word);
                }
                wordId++;
            }
            var lines = OcrLoaderHelper.GetLines(words, mainRegion, info);
            mainRegion.Lines = lines;
            mainRegion.Location = new OcrLocation();
            mainRegion.Location.X = mainRegion.Lines.Min(i => i.Location.X);
            mainRegion.Location.Width = mainRegion.Lines.Max(i => i.Location.XBound) - mainRegion.Location.X;
            mainRegion.Location.Y = mainRegion.Lines.Min(i => i.Location.Y);
            mainRegion.Location.Height = mainRegion.Lines.Max(i => i.Location.YBound) - mainRegion.Location.Y;
            mainRegion.Location.RelativeLocation = OcrRelativeLocation.Load(mainRegion.Location, info);
            result.Regions.Add(mainRegion);
            result.Words = words;
            result.Lines = lines;
            return result;
        }

        private OcrLocation GetLocation(JToken json, ImageInfo info)
        {
            var result = new OcrLocation();
            var boxVals = json["boundingPoly"]["vertices"].Value<JArray>();
            result.X = boxVals[0]["x"].Value<int>();
            result.Width = boxVals[1]["x"].Value<int>() - result.X;
            result.Y = boxVals[0]["y"].Value<int>();
            result.Height = boxVals[2]["y"].Value<int>() - result.Y;
            result.RelativeLocation = OcrRelativeLocation.Load(result, info);
            return result;
        }
    }
}
