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
            var payload = JsonConvert.SerializeObject(new GoogleVisionPayload(image));
            request.AddHeader("Content-type", "application/json");
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("application/json", new GoogleVisionPayload(image), ParameterType.RequestBody);
            return client.Execute(request);
        }
    }

    public class GoogleVisionPayload
    {
        public GoogleVisionPayload(byte[] image)
        {
            Requests = new List<GoogleRequest>()
            { new GoogleRequest() {  Images = new GoogleRequestImage(image) } };
        }

        [JsonProperty(PropertyName = "requests")]
        public List<GoogleRequest> Requests { get; set; }
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

        public GoogleRequestImage()
        {

        }
        public GoogleRequestImage(byte[] data)
        {
            Load(data);
        }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        public void Load(byte[] data)
        {
            Content = Convert.ToBase64String(data);
        }
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
