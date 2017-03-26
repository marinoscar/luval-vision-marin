using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using System.Configuration;

namespace luval.vision.core
{
    public class MicrosoftOcrEngine : IOcrEngine
    {
        public IRestResponse Execute(string name, byte[] image)
        {
            var apiKey = ConfigurationManager.AppSettings["azure.vision.key"];
            var client = new RestClient("https://api.projectoxford.ai/vision/v1.0/ocr");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Ocp-Apim-Subscription-Key", apiKey);
            request.AddHeader("Content-Type", "multipart/form-data");
            //request.AddFile("content", name);
            request.AddFileBytes("content", image, name);
            return client.Execute(request);
        }
    }
}
