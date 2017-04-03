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

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class StorageController : ApiController
    {
        private OcrBlobStorage ocrBlobStorage;

        public StorageController()
        {
            ocrBlobStorage = new OcrBlobStorage();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                IEnumerable<IListBlobItem> blobs = ocrBlobStorage.GetFilesBlobStorage();
                if (!blobs.Equals(null))
                {
                    if(blobs.Count() > 0)
                        return Ok(blobs);
                }
                return Content(HttpStatusCode.InternalServerError, "The user couldn't be registered");
            }
            catch (System.Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }


    }
}
