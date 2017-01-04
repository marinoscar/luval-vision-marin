using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace luval.vision.core
{
    public class OcrProvider
    {

        public OcrResult DoOcr(FileInfo file)
        {
            var response = DoOcrRequest(file);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Unable to process request");
            return JsonConvert.DeserializeObject<OcrResult>(response.Content);
        }


        private IRestResponse DoOcrRequest(string  fileName)
        {
            var apiKey = ConfigurationManager.AppSettings["azure.vision.key"];
            var client = new RestClient("https://api.projectoxford.ai/vision/v1.0/ocr");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Ocp-Apim-Subscription-Key", apiKey);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddFile("content", file.FullName);
            return client.Execute(request);
        }
    }
}
