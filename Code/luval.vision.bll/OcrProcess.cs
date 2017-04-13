using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.core;
using luval.vision.entity;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace luval.vision.bll
{
    public class OcrProcess
    {
        public OcrProcess()
        {
        }

        public OcrProvider GetProvider(bool ms)
        {
            return !ms ? new OcrProvider(new GoogleOcrEngine(), new GoogleVisionLoader()) : new OcrProvider(new MicrosoftOcrEngine(), new MicrosoftVisionLoader());
        }

        public string DoSaveResult(string fileName, ProcessResult processResult)
        {
            var data = new FormResult()
            {
                FileName = fileName,
                FileData = File.ReadAllBytes(fileName),
                Result = processResult
            };
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return json;
        }

        public string DoSaveResult(byte[] stream, string fileName, ProcessResult processResult)
        {
            var data = new FormResult()
            {
                FileName = fileName,
                FileData = stream,
                Result = processResult
            };
            var json = JsonConvert.SerializeObject(data, Formatting.None, new JsonSerializerSettings() { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            return json;
        }

        public ProcessResult DoProcess(string fileName, string extension)
        {
            var jsonData = File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/attribute-mapping.json"));
            var options = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData); // TODO USE THIS OPTIONS
            var provider = new DocumentProcesor(GetProvider(false), new NlpProvider(new GoogleNlpEngine(), new GoogleNlpLoader()));
            var result = provider.DoProcess(fileName, options, extension);
            return result;
        }

        private void LoadText(OcrResult ocrResult)
        {
            var sb = new StringBuilder();
            foreach (var line in ocrResult.Lines)
            {
                sb.AppendLine(line.Text);
            }
        }


        private List<MappingResult> GetData(OcrResult result)
        {
            var jsonData = File.ReadAllText("attribute-mapping.json");
            var options = JsonConvert.DeserializeObject<List<AttributeMapping>>(jsonData);
            var navigator = new Navigator(result.Info, result.Lines, options);
            return navigator.ExtractAttributes();
        }
    }
}
