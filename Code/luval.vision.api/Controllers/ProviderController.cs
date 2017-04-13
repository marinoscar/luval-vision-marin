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
using luval.vision.dal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;
using System.IO;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProviderController : ApiController
    {
        private OcrProcess processOcr;
        private OcrBlobStorage blobStorageOcr;
        private DocumentDAL documentDAL;

        public ProviderController()
        {
            processOcr = new OcrProcess();
            blobStorageOcr = new OcrBlobStorage();
            processOcr = new OcrProcess();
            documentDAL = new DocumentDAL();
        }

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
                var userId = result.FormData.GetValues(0).FirstOrDefault();
                foreach (MultipartFileData file in result.FileData)
                {
                    processResult = processOcr.DoProcess(file.LocalFileName, originalFileName);
                    var bytes = Pdf2Img.CheckForPdfAndConvert(File.ReadAllBytes(file.LocalFileName), file.LocalFileName, file.Headers.ContentDisposition.FileName);
                    processResult.UserId = userId;
                    documentDAL.SaveOrUpdate(getOcrDocument(processResult, processOcr, file.LocalFileName, originalFileName, bytes));
                    blobStorageOcr.UploadFileBlobStorage(file.LocalFileName, file.Headers.ContentDisposition.FileName, processResult);
                    jsonResult = processOcr.DoSaveResult(bytes, file.LocalFileName, processResult);
                }
                return Ok(jsonResult);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.ToString());
            }
        }

        private OcrDocument getOcrDocument(ProcessResult result, OcrProcess process, string path, string fileName, byte[] data)
        {
            return new OcrDocument
            {
                Id = fileName,
                DocumentId = result.Id,
                UserId = result.UserId,
                DurationInMs = result.DurationInMs,
                Content = process.DoSaveResult(data, path, result)
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