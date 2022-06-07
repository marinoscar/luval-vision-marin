using luval.vision;
using luval.vision.core;
using luval.vision.google;
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
        public ExtractionPackage DoExtraction(SecureString apiKey, string filePath, string jsonConfiguration)
        {
            if (apiKey == null) throw new ArgumentNullException("apiKey");
            if (string.IsNullOrWhiteSpace(filePath)) throw new ArgumentNullException("filePath");
            if (string.IsNullOrWhiteSpace(jsonConfiguration)) throw new ArgumentNullException("jsonConfiguration");
            var fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists) throw new ArgumentException("File does not exists", "filePath");
            var ocr = GetProvider(apiKey);
            var options = new ConfigOptions();
            var result = new List<ExtractionResult>();
            try
            {
                options = GetOptions(jsonConfiguration);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Unable to parse the json configuration", "jsonConfiguration", ex);
            }
            var bytes = File.ReadAllBytes(filePath);
            OcrResult ocrResult = new OcrResult();
            try
            {
                ocrResult = ocr.DoOcr(fileInfo.FullName);
                var extractor = new Extractor(options, ocrResult.Regions.First(), ocrResult.Info);
                result.AddRange(extractor.GetValues());
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Unable to process the OCR request or parsing of the elements", ex);
            }
            var dt = GetResult(result);
            return new ExtractionPackage() { Table = dt, OcrResult = ocrResult };
        }

        private DataTable GetResult(IEnumerable<ExtractionResult> results)
        {
            var dt = new DataTable("Results");
            dt.Columns.Add("Field", typeof(string));
            dt.Columns.Add("Value", typeof(string));
            foreach(var item in results)
            {
                var row = dt.NewRow();
                row["Field"] = item.Option.FieldName;
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

        private ConfigOptions GetOptions(string jsonConfiguration)
        {
            return JsonConvert.DeserializeObject<ConfigOptions>(jsonConfiguration);
        }
    }
}
