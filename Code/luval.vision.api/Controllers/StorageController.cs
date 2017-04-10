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
using luval.vision.dal;
using luval.vision.core;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StorageController : ApiController
    {
        private OcrBlobStorage ocrBlobStorage;
        private DocumentDAL documentDAL;
        private OcrProcess processOcr;

        public StorageController()
        {
            ocrBlobStorage = new OcrBlobStorage();
            documentDAL = new DocumentDAL();
            processOcr = new OcrProcess();
        }

        public IHttpActionResult Post(OcrUser user)
        {
            try
            {
                ProcessResult processResult = new ProcessResult();
                IEnumerable<OcrDocument> documents = documentDAL.GetProcessResultByUserId(user.id);
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
