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
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        [JsonProperty(PropertyName = "textAngle")]
        public decimal TextAngle { get; set; }
        [JsonProperty(PropertyName = "orientation")]
        public string Orientation { get; set; }
        [JsonProperty(PropertyName = "regions")]
        public JArray Regions { get; set; }
    }
}
