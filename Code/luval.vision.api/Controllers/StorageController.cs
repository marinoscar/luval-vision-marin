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
        private DocumentLogic documentLogic;

        public StorageController()
        {
            documentLogic = new DocumentLogic();
        }

        [BasicAuthentication]
        public IHttpActionResult Get(string userId)
        {
            try
            {
                IEnumerable<OcrDocument> documents;
                documents = documentLogic.GetProcessResultByUserId(userId);
                if (documentCollectionIsNotNull(documents))
                {
                    return Ok(documents);
                }
                return InternalServerError();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        private bool documentCollectionIsNotNull(IEnumerable<OcrDocument> documents)
        {
            return !documents.Equals(null);
        }
    }
}
