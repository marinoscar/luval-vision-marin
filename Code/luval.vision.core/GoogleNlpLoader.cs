using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace luval.vision.core
{
    public class GoogleNlpLoader : INlpLoader
    {
        public NlpResult Load(string jsonResult)
        {
            var json = JObject.Parse(jsonResult);
            var result = new NlpResult() { Entities = new List<NlpEntity>() };
            result.Language = json["language"].Value<string>();
            var jsonEntities = json["entities"].Value<JArray>();
            foreach(var jsonEnt in jsonEntities)
            {
                var ent = new NlpEntity()
                {
                    Name = jsonEnt["name"].Value<string>(),
                    Score = jsonEnt["salience"].Value<float>(),
                    Type = MapType(jsonEnt["type"].Value<string>()),
                    Metadata = GetMetadata(jsonEnt["metadata"])
                };
            }
            return result;
        }

        private EntityType MapType(string type)
        {
            if (string.IsNullOrWhiteSpace(type) || type.ToUpperInvariant().Equals("OTHER") || type.ToUpperInvariant().Equals("UNKNOWN")) return EntityType.None;
            return (EntityType)Enum.Parse(typeof(EntityType), type, true);

        }

        private IDictionary<string, string> GetMetadata(JToken token)
        {
            var res = new Dictionary<string, string>();
            if (token["wikipedia_url"] != null) res["url"] = token["wikipedia_url"].Value<string>();
            return res;
        }
    }
}
