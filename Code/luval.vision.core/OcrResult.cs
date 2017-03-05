using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class OcrResult
    {
        public OcrResult()
        {
            Regions = new List<OcrRegion>();
            Words = new List<OcrWord>();
        }

        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "textAngle")]
        public decimal TextAngle { get; set; }
        [JsonProperty(PropertyName = "orientation")]
        public string Orientation { get; set; }
        [JsonProperty(PropertyName = "regions")]
        public JArray RegionResult { get; set; }

        public List<OcrRegion> Regions { get; set; }
        public List<OcrWord> Words { get; set; }

        public void LoadFromJsonRegion()
        {
            var id = 1;
            foreach (var jRegion in RegionResult)
            {
                var region = new OcrRegion()
                {
                    RegionId = id,
                    Location = ParseBox(jRegion)
                };
                foreach(var jLine in jRegion["lines"])
                {
                    var line = new OcrLine()
                    {
                        ParentRegion = region,
                        Location = ParseBox(jLine),
                    };
                    foreach(var jWord in jLine["words"])
                    {
                        var word = ParseWord(jWord, line);
                        line.Words.Add(word);
                        EntityExtractor.ClassifyWord(word);
                        Words.Add(word);
                    }
                    region.Lines.Add(line);
                }
                Regions.Add(region);
                id++;
            }
        }

        private OcrWord ParseWord(JToken token, OcrLine line)
        {
            var word = new OcrWord()
            {
                ParentLine = line,
                Location = ParseBox(token),
                Text = Convert.ToString(token["text"])
            };
            return word;
        }

        private OcrLocation ParseBox(JToken token)
        {
            if (token["boundingBox"] == null) return default(OcrLocation);
            var vals = token["boundingBox"].Value<string>().Split(",".ToCharArray());
            return new OcrLocation() {
                X = Convert.ToInt32(vals[0]),
                Y = Convert.ToInt32(vals[1]),
                Width = Convert.ToInt32(vals[2]),
                Height = Convert.ToInt32(vals[3]),
            };
        }
    }
}
