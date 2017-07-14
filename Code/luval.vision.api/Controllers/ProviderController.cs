using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using luval.vision.bll;
using luval.vision.core;
using Newtonsoft.Json;
using luval.vision.entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using System.IO;
using luval.vision.api.Security;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProviderController : ApiController
    {
        private ProcessLogic processOcr;
        private BlobStorageLogic blobStorageLogic;
        private DocumentLogic documentLogic;

        public ProviderController()
        {
            processOcr = new ProcessLogic();
            blobStorageLogic = new BlobStorageLogic();
            processOcr = new ProcessLogic();
            documentLogic = new DocumentLogic();
        }

        [BasicAuthentication]
        public IHttpActionResult Get(string id)
        {
            var ocrDocument = documentLogic.GetProcessResultById(id);
            if (ocrDocument != null)
                return Ok(ocrDocument);
            return BadRequest();
        }

        [BasicAuthentication]
        public async Task<IHttpActionResult> Post()
        {
            ProcessResult processResult = new ProcessResult();
            string jsonResult = string.Empty;
            if (!Request.Content.IsMimeMultipartContent())
            {
                this.Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }

            var provider = GetMultipartProvider();
            try
            {
                var result = await Request.Content.ReadAsMultipartAsync(provider);
                var originalFileName = GetDeserializedFileName(result.FileData.First());
                var userId = result.FormData.GetValues(1).FirstOrDefault();
                var profileName = result.FormData.GetValues(0).FirstOrDefault();
                foreach (MultipartFileData file in result.FileData)
                {
                    processResult = processOcr.DoProcess(file.LocalFileName, originalFileName, userId, profileName);
                    var bytes = Pdf2Img.CheckForPdfAndConvert(File.ReadAllBytes(file.LocalFileName), file.LocalFileName, file.Headers.ContentDisposition.FileName);
                    processResult.UserId = userId;
                    documentLogic.Save(getOcrDocument(processResult, processOcr, file.LocalFileName, originalFileName, bytes, profileName));
                    blobStorageLogic.UploadFileBlobStorage(file.LocalFileName, file.Headers.ContentDisposition.FileName, processResult);
                    jsonResult = processOcr.DoSaveResult(bytes, file.LocalFileName, processResult);
                }
                return Ok(jsonResult);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        private OcrDocument getOcrDocument(ProcessResult result, ProcessLogic process, string path, string fileName, byte[] data, string profileName)
        {
            return new OcrDocument
            {
                Id = result.Id,
                UserId = result.UserId,
                DurationInMs = result.DurationInMs,
                Content = process.DoSaveResult(data, path, result),
                ProfileName = profileName
            };
        }

        private MultipartFormDataStreamProvider GetMultipartProvider()
        {
            var root = HttpContext.Current.Server.MapPath("~/App_Data/documents/");
            Directory.CreateDirectory(root);
            return new MultipartFormDataStreamProvider(root);
        }

        private string GetDeserializedFileName(MultipartFileData fileData)
        {
            var fileName = GetFileName(fileData);
            return JsonConvert.DeserializeObject(fileName).ToString();
        }

        private string GetFileName(MultipartFileData fileData)
        {
            return fileData.Headers.ContentDisposition.FileName;
        }
    }
}
