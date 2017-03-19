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
using System.Text.RegularExpressions;
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
            var result = JsonConvert.DeserializeObject<OcrResult>(response.Content);
            result.LoadFromJsonRegion();
            result.HorizontalLines.AddRange(GetLines(result));
            return result;
        }

        public ParseResult DoParseResult(IEnumerable<LineItem> lines)
        {
            var result = new ParseResult() {
                Total = GetTotal(lines), Tax = GetLineNumberValue(lines,"tax")
            };
            return result;
        }

        public IEnumerable<LineItem> GetLines(OcrResult item)
        {
            var result = new List<OcrArea>();
            var id = 1;
            var regionId = 1;
            foreach (var region in item.JsonResult)
            {
                foreach (var line in region.Value<JArray>("lines"))
                {
                    var box = line.Value<string>("boundingBox").Split(",".ToCharArray()).Select(i => Convert.ToInt32(i)).ToArray();
                    var words = line.Value<JArray>("words").Select(i => i.Value<string>("text")).ToArray();
                    result.Add(new OcrArea()
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

        public string GetTotal(string fileName)
        {
            var result = DoOcr(fileName);
            return GetTotal(GetLines(result));
        }

        public string GetTotal(IEnumerable<LineItem> lines)
        {
            return GetLineNumberValue(lines, "total");
        }

        public string GetLineNumberValue(IEnumerable<LineItem> lines, string pattern)
        {
            var text = string.Empty;
            foreach (var item in lines.Reverse())
            {
                text = item.ToText();
                if (text.ToLowerInvariant().Contains(pattern))
                {
                    var amountValues = Regex.Matches(text, @"[0-9]|-|\.|,").Cast<Match>().Where(i => i.Success).Select(i => i.Value).ToList();
                    return string.Join("", amountValues);
                }
            }
            return string.Empty;
        }



        private IEnumerable<LineItem> AlignLines(IEnumerable<OcrArea> items)
        {
            var resultLineItems = new List<LineItem>();
            var offset = (int)(items.Max(i => i.Height) * 0.05); //Lines within 5% of the selected Y axis
            var lineNo = 1;
            var iterator = items.OrderBy(i => i.Y).ToList();
            while (iterator.Count > 0)
            {
                var item = iterator.First();
                var min = item.Y - offset;
                var max = item.Y + offset;
                var similar = iterator.Where(i => i.Id != item.Id && (i.Y >= min && i.Y < max)).ToList();
                if (similar.Count > 0)
                {
                    var tmp = new List<OcrArea>(similar) { item };
                    tmp.ForEach(i => iterator.Remove(i));
                    resultLineItems.Add(new LineItem()
                    {
                        LineNumber = lineNo,
                        Areas = tmp.OrderBy(i => i.X).ToList() //order from left to right
                    });
                }
                else
                {
                    iterator.Remove(item);
                    resultLineItems.Add(new LineItem()
                    {
                        LineNumber = lineNo,
                        Areas = new[] { item } //order from left to right
                    });
                }
                lineNo++;
            }
            return resultLineItems;
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
