using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.entity
{
    public class OcrDocument
    {
        [BsonId]
        public string Id { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("duration_inms")]
        public double DurationInMs { get; set; }
        [BsonElement("process_result")]
        public string Content { get; set; }
    }
}
