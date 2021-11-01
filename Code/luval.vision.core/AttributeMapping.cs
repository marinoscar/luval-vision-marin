using Microsoft.Recognizers.Text.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
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
        [JsonProperty(PropertyName = "attributeIndex")]
        public int? AttributeIndex { get; set; }
        [JsonProperty(PropertyName = "isValueLast")]
        public bool IsValueLast { get; set; }
        [JsonProperty(PropertyName = "cleanLeft")]
        public bool CleanLeft { get; set; }
        [JsonProperty(PropertyName = "areaSearchX")]
        public double AreaSearchX { get; set; }
        [JsonProperty(PropertyName = "areaSearchY")]
        public double AreaSearchY { get; set; }
        [JsonProperty(PropertyName = "getTopLine")]
        public bool GetTopLine { get; set; }

        [JsonProperty(PropertyName = "areaSearchTopX")]
        public double AreaSearchTopX { get; set; }
        [JsonProperty(PropertyName = "areaSearchTopY")]
        public double AreaSearchTopY { get; set; }

        [JsonProperty(PropertyName = "areaSearch")]
        public bool AreaSearch { get; set; }
        [JsonProperty(PropertyName = "areaSearchWordCount")]
        public int AreaSearchWordCount { get; set; }

        public OcrLocation GetAreaSearch(OcrRegion region)
        {
            return OcrRelativeLocation.FromRelative(region, AreaSearchX, AreaSearchTopX, AreaSearchY, AreaSearchTopY);
        }
    }
}
