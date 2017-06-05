using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace luval.vision.entity
{
    public class OcrUser
    {
        [JsonProperty("id")]
        public string id { get; set; }
    }
}
