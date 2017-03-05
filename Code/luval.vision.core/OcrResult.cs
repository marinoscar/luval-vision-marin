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
    }
}
