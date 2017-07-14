using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MongoDB.Bson.Serialization.Attributes;

namespace luval.vision.entity
{
    public class OcrUser
    {
        [BsonId]
        public string Id { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("is_enabled")]
        public bool IsEnabled { get; set; }
        [BsonElement("utc_last_login_date")]
        public DateTime UtcLastLoginDate { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("role")]
        public string Role { get; set; }
        [BsonElement("user_id")]
        public string UserId { get; set; }
        [BsonElement("api_token")]
        public string ApiToken { get; set; }
        [BsonElement("utc_api_token_expiration_date")]
        public string UtcApiTokenExpirationDate { get; set; }
        [BsonElement("is_approved")]
        public bool IsApproved { get; set; }
    }
}
