using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class MicrosoftVisionLoader : IVisionResultParser
    {
        public OcrResult DoParse(string jsonResult, ImageInfo info)
        {
            var json = (JObject)JsonConvert.DeserializeObject(jsonResult);
            var result = new OcrResult()
            {
                Language = json["language"].Value<string>(),
                Orientation = json["orientation"].Value<string>(),
                TextAngle = json["textAngle"].Value<decimal>(),
                Info = info
            };
            LoadFromJsonRegion(json["regions"].Value<JArray>(), result);
            return result;
        }

        private void LoadFromJsonRegion(JArray regions, OcrResult result)
        {
            var regionId = 1;
            foreach (var jRegion in regions)
            {
                var region = new OcrRegion()
                {
                    Id = regionId,
                    Code = regionId.ToString().PadLeft(3, '0'),
                    Location = ParseBox(jRegion, result)
                };
                var lineId = 1;
                foreach (var jLine in jRegion["lines"])
                {
                    var line = new OcrLine()
                    {
                        Id = lineId,
                        Code = string.Format("{0}.{1}", region.Code, lineId.ToString().PadLeft(4, '0')),
                        ParentRegion = region,
                        Location = ParseBox(jLine, result),
                    };
                    var wordId = 1;
                    foreach (var jWord in jLine["words"])
                    {
                        var word = ParseWord(jWord, line, result);
                        word.Code = string.Format("{0}.{1}", line.Code, wordId.ToString().PadLeft(5, '0'));
                        line.Words.Add(word);
                        EntityExtractor.ClassifyWord(word);
                        result.Words.Add(word);
                        wordId++;
                    }
                    region.Lines.Add(line);
                    result.Lines.Add(line);
                    lineId++;
                }
                result.Regions.Add(region);
                regionId++;
            }
        }

        private OcrLocation ParseBox(JToken token, OcrResult res)
        {
            if (token["boundingBox"] == null) return default(OcrLocation);
            var vals = token["boundingBox"].Value<string>().Split(",".ToCharArray());
            var result = new OcrLocation()
            {
                X = Convert.ToInt32(vals[0]),
                Y = Convert.ToInt32(vals[1]),
                Width = Convert.ToInt32(vals[2]),
                Height = Convert.ToInt32(vals[3])
            };
            result.RelativeLocation = OcrRelativeLocation.Load(result, res.Info);
            return result;
        }

        private OcrWord ParseWord(JToken token, OcrLine line, OcrResult result)
        {
            var word = new OcrWord()
            {
                ParentLine = line,
                Location = ParseBox(token, result),
                Text = Convert.ToString(token["text"])
            };
            return word;
        }
    }
}
