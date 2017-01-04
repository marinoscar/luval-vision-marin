using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

        public OcrResult DoOcr(string fileName)
        {
            var response = DoOcrRequest(fileName);
            if (response.StatusCode != HttpStatusCode.OK)
                throw new InvalidOperationException("Unable to process request");
            return JsonConvert.DeserializeObject<OcrResult>(response.Content);
        }

        public string[] GetLines(OcrResult item)
        {
            var result = new List<LineItem>();
            var id = 1;
            var regionId = 1;
            foreach (var region in item.Regions)
            {
                foreach (var line in region.Value<JArray>("lines"))
                {
                    var box = line.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                    var words = line.Value<JArray>("words").Select(i => i.Value<string>("text")).ToArray();
                    result.Add(new LineItem()
                    {
                        Id = id,
                        RegionId = regionId,
                        X = box[0],
                        Y = box[1],
                        Height = box[2],
                        Width = box[3],
                        Words = words 
                    });
                    id++;
                }
                regionId++;
            }
            return AlignLines(result);
        }

        private string[] AlignLines(IEnumerable<LineItem> items)
        {
            var linesProcessed = new List<int>();
            var offset = (int)(items.Max(i => i.Height) * 0.05); //Lines within 5% of the selected Y axis
            var buffer = new Dictionary<int, List<LineItem>>();
            foreach(var item in items.OrderBy(i => i.Y).ToList()) //Start from Top to Bottom
            {
                var min = item.Y - offset;
                var max = item.Y + offset;
                var similar = items.Where(i => i.Id != item.Id && !linesProcessed.Contains(i.Id) && (i.Y >= min && i.Y < max)).ToList();
                var index = buffer.Keys.Count;
                if (similar.Count > 0)
                {
                    linesProcessed.AddRange(similar.Select(i => i.Id));
                    var tmp = new List<LineItem>(similar) { item };
                    buffer[index] = tmp.OrderBy(i => i.X).ToList(); //order from left to right
                }
                else if(!linesProcessed.Contains(item.Id))
                {
                    buffer[index] = new List<LineItem>() { item };
                }
                else
                    linesProcessed.Add(item.Id);
            }
            return buffer.Select(i => string.Join("     ", i.Value.Select(j => string.Join(" ", j.Words)))).Distinct().ToArray();
        }

        private IRestResponse DoOcrRequest(string fileName)
        {
            var apiKey = ConfigurationManager.AppSettings["azure.vision.key"];
            var client = new RestClient("https://api.projectoxford.ai/vision/v1.0/ocr");
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Ocp-Apim-Subscription-Key", apiKey);
            request.AddHeader("Content-Type", "multipart/form-data");
            request.AddFile("content", fileName);
            return client.Execute(request);
        }
    }
}
