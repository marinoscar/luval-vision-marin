using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using System.Web;
using System.Text.RegularExpressions;

using luval.vision.core;
using luval.vision.bll;
using luval.vision.entity;
using luval.vision.api.Security;
using luval.vision.api.Statistics;


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
                if (CollectionValidator.IEnumerableCollectionIsNotNull(documents))
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

        [Route("api/v1/Storage/GetStatistics")]
        [HttpGet]
        [BasicAuthentication]
        public IHttpActionResult GetStatistics(string userId, string year, string month)
        {
            IEnumerable<DocumentStatistics> dateOccurrencePairsList;
            dateOccurrencePairsList = documentLogic.GetDocumentStatisticsByUserId(userId, year, month);

            StatisticsDataGenerator generator = new StatisticsDataGenerator();
            Data returnData = generator.GenerateDataFromDateOccurrencePairs(dateOccurrencePairsList);

            return Ok(returnData);
        }
    }
}
