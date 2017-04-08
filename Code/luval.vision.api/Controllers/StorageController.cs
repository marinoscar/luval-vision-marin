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

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StorageController : ApiController
    {
        private OcrBlobStorage ocrBlobStorage;
        private OcrProcess processOcr;

        public StorageController()
        {
            ocrBlobStorage = new OcrBlobStorage();
            processOcr = new OcrProcess();
        }

        public IHttpActionResult Post(OcrUser ocrUser)
        {
            try
            {
                ProcessResult processResult = new ProcessResult();
                IEnumerable<IListBlobItem> blobs = ocrBlobStorage.GetFilesBlobStorage(ocrUser.id);
                if (!blobs.Equals(null))
                {
                    if(blobs.Count() > 0)
                        return Ok(blobs);
                }
                return InternalServerError();
            }
            catch (System.Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }


    }
}
