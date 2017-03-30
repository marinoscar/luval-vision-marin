using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class AttributeMapping
    {
        [JsonProperty(PropertyName = "attributeName")]
        public string AttributeName { get; set; }
        [JsonProperty(PropertyName = "anchorPatterns")]
        public string[] AnchorPatterns { get; set; }
        [JsonProperty(PropertyName = "valueDirection")]
        public Direction ValueDirection { get; set; }
        [JsonProperty(PropertyName = "valuePatterns")]
        public string[] ValuePatterns { get; set; }
        [JsonProperty(PropertyName = "isAttributeLast")]
        public bool IsAttributeLast { get; set; }
        [JsonProperty(PropertyName = "isValueLast")]
        public bool IsValueLast { get; set; }
    }
}
