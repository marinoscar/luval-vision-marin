using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace luval.vision.entity
{
    public class OcrUser
    {
        [BsonId]
        [JsonProperty("id")]
        public String id { get; set; }
        [BsonElement("token_id")]
        [JsonProperty("token_id")]
        public String tokenId { get; set; }
    }
}
