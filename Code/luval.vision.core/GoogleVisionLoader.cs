using Newtonsoft.Json.Linq;
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
            var json = JObject.Parse(jsonResult);
            var result = new OcrResult();
            var mainRegion = new OcrRegion()
            {
                Id = 1, Code = OcrLoaderHelper.GetRegionCode(1)
            };
            var annotations = json["responses"]["textAnnotations"].Value<JArray>();
            var lineId = 1;
            foreach (var ann in annotations)
            {
                var line = new OcrLine()
                {
                    Id = lineId, Code = OcrLoaderHelper.GetLineCode(lineId, mainRegion),
                    Location = GetLocation(ann, info), ParentRegion = mainRegion, Text = ann["description"].Value<string>()
                };
                lineId++;
            }
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
