using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using luval.vision.bll;
using System.Threading.Tasks;
using System.Web;
using luval.vision.entity;
using luval.vision.core;
using luval.vision.api.Security;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StorageController : ApiController
    {
        private BlobStorageLogic ocrBlobStorage;
        private DocumentLogic documentLogic;
        private ProcessLogic processOcr;

        public StorageController()
        {
            ocrBlobStorage = new BlobStorageLogic();
            documentLogic = new DocumentLogic();
            processOcr = new ProcessLogic();
        }

        [BasicAuthentication]
        public IHttpActionResult Get(string userId)
        {
            try
            {
                ProcessResult processResult = new ProcessResult();
                IEnumerable<OcrDocument> documents = documentLogic.GetProcessResultByUserId(userId);
                if (!documents.Equals(null))
                {
                    if(documents.Count() > 0)
                        return Ok(documents);
                }
                return InternalServerError();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
