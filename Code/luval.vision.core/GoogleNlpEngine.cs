using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;
using Newtonsoft.Json;

namespace luval.vision.core
{
    public class GoogleNlpEngine : INlpEngine
    {
        public IRestResponse ProcessText(string text)
        {
            var apiKey = ConfigurationManager.AppSettings["google.vision.key"];
            var client = new RestClient(string.Format("https://language.googleapis.com/v1/documents:analyzeEntities?key={0}", apiKey));
            var request = new RestRequest(Method.POST);
            var payload = JsonConvert.SerializeObject(new GoogleNlpRequest(text));
            request.AddHeader("Content-type", "application/json");
            request.AddHeader("Content-Length", payload.Length.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json; charset=utf-8", payload, ParameterType.RequestBody);
            return client.Execute(request);
        }

        public class GoogleNlpRequest
        {

            public GoogleNlpRequest(string text)
            {
                EncodingType = "UTF8";
                Document = new GoogleNlpRequestDocument() {  Content = text  };
            }
            [JsonProperty(PropertyName = "encodingType")]
            public string EncodingType { get; set; }
            [JsonProperty(PropertyName = "document")]
            public GoogleNlpRequestDocument Document { get; set; }

        }

        public class GoogleNlpRequestDocument
        {

            public GoogleNlpRequestDocument()
            {
                Type = "PLAIN_TEXT";
            }
            [JsonProperty(PropertyName = "type")]
            public string Type { get; set; }
            [JsonProperty(PropertyName = "content")]
            public string Content { get; set; }
        }
    }
}
