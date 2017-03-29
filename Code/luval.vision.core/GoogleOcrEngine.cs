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
    public class GoogleOcrEngine : IOcrEngine
    {
        public IRestResponse Execute(string name, byte[] image)
        {
            var apiKey = ConfigurationManager.AppSettings["google.vision.key"];
            var client = new RestClient(string.Format("https://vision.googleapis.com/v1/images:annotate?key={0}", apiKey));
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            //request.AddHeader("Content-Type", "multipart/form-data");

            request.AddFileBytes("content", image, name);
            return client.Execute(request);
        }
    }

    public class GoogleRequest
    {
        public GoogleRequest()
        {
            Images = new GoogleRequestImage();
            Features = new List<GoogleRequestFeature>() { new GoogleRequestFeature() };
        }

        [JsonProperty(PropertyName = "images")]
        public GoogleRequestImage Images { get; set; }
        [JsonProperty(PropertyName = "features")]
        public List<GoogleRequestFeature> Features { get; set; }
    }

    public class GoogleRequestImage
    {
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }

    public class GoogleRequestFeature
    {
        public GoogleRequestFeature()
        {
            Type = "TEXT_DETECTION";
        }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }
}
