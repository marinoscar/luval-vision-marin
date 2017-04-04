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
    public class OcrDocument
    {
        [BsonId]
        [JsonProperty("id")]
        public String id { get; set; }
        [BsonElement("user_id")]
        [JsonProperty("user_id")]
        public String userId { get; set; }
        [BsonElement("document_id")]
        [JsonProperty("document_id")]
        public String documentId { get; set; }
    }
}
