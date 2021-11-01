using luval.vision.core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Luval.FormExtractor
{
    public class ExtractorHelper
    {
        public DataTable DoExtraction(SecureString apiKey, string filePath, string jsonConfiguration)
        {
            if (apiKey == null) throw new ArgumentNullException("apiKey");
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException("filePath");
            if (string.IsNullOrWhiteSpace(jsonConfiguration)) throw new ArgumentNullException("jsonConfiguration");
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) throw new ArgumentException("File does not exists", "filePath");
            var ocr = GetProvider(apiKey);
            var options = GetOptions(jsonConfiguration);
            var bytes = File.ReadAllBytes(filePath);
            var docProvider = new DocumentProcesor(ocr);
            var result = docProvider.DoProcess(bytes, filePath, options);
            var dt = GetResult(result.TextResults);
            return dt;
        }

        private DataTable GetResult(IEnumerable<MappingResult> results)
        {
            var dt = new DataTable("Results");
            dt.Columns.Add("Field", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            foreach(var item in results)
            {
                var row = dt.NewRow();
                row["Field"] = item.Map.AttributeName;
                row["Value"] = item.Value;
                dt.Rows.Add(row);
            }
            return dt;
        }

        private OcrProvider GetProvider(SecureString apiKey)
        {
            var credential = new NetworkCredential("googleApi", apiKey);
            return new OcrProvider(new GoogleOcrEngine(credential.Password), new GoogleVisionLoader());
        }

        private List<AttributeMapping> GetOptions(string jsonConfiguration)
        {
            return JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonConfiguration);
        }
    }
}
