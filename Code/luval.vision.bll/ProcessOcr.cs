using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace luval.vision.bll
{
    public class OcrProcess
    {
        public TreeProcess DoProcess(OcrResult ocrResult)
        {
            List<string[]> ListAttributes = new List<string[]>();
            var items = GetData(ocrResult);
            foreach(var item in items)
            {
                ListAttributes.Add(new string[] { item.Map.AttributeName, item.ResultElement.Text });
            }

            TreeProcess tree = new TreeProcess
            {
                mappingResult = ListAttributes,
                text = LoadText(ocrResult)
            };
            return tree;
        }

        private string LoadText(OcrResult ocrResult)
        {
            var sb = new StringBuilder();
            foreach (var line in ocrResult.Lines)
            {
                sb.AppendLine(line.Text);
            }
            return sb.ToString();
        }

        private List<MappingResult> GetData(OcrResult result)
        {
            var jsonData = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/attribute-mapping.json"));
            var options = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData);
            var navigator = new Navigator(result.Info, result.Lines, options);
            return navigator.ExtractAttributes();
        }
    }
}
