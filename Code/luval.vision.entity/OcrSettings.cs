using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.core;
using MongoDB.Bson.Serialization.Attributes;

namespace luval.vision.entity
{
    public class OcrSettings
    {
        [BsonId]
        public string Id { get; set; }
        [BsonElement("user_id")]
        public string userId { get; set; }
        [BsonElement("attribute_mapping")]
        public AttributeMapping[] attributeMapping { get; set; }
        [BsonElement("profile_name")]
        public string profileName { get; set; }
    }
}
