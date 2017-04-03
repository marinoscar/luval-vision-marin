using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using luval.vision.bll;
using Newtonsoft.Json;
using luval.vision.entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Cors;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProviderController : ApiController
    {
        private OcrProvider providerOcr;
        private OcrProcess processOcr;
        private OcrResult _result;
        private OcrBlobStorage blobStorageOcr;

        public ProviderController()
        {
            processOcr = new OcrProcess();
            providerOcr = new OcrProvider(new MicrosoftOcrEngine(), new MicrosoftVisionLoader());
            blobStorageOcr = new OcrBlobStorage();
        }

        public async Task<IHttpActionResult> Post()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            string root = HttpContext.Current.Server.MapPath("~/App_Data");
            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData file in provider.FileData)
                {
                    String guid = Guid.NewGuid().ToString();
                    blobStorageOcr.UploadFileBlobStorage(file.LocalFileName, file.Headers.ContentDisposition.FileName, guid);
                    var result = providerOcr.DoOcr(file.LocalFileName);
                    _result = result;
                }

                return Ok(processOcr.DoProcess(_result));
            }
            catch (System.Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

    }
}
