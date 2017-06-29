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
using luval.vision.api.Models;
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

        [Route("api/v1/Storage/GetStatistics")]
        [HttpGet]
        public IHttpActionResult GetStatistics(string userId)
        {
            IEnumerable<OcrDocument> documents;
            documents = documentLogic.GetProcessResultByUserId(userId);

            if (documentCollectionIsNotNull(documents) && documents.Count() > 0)
            {
                Data returnData = GetStatisticsData(documents);
                return Ok(returnData);
            }
            else
            {
                return InternalServerError();
            }
        }

        private Data GetStatisticsData(IEnumerable<OcrDocument> documents)
        {
            Data StatisticsData = InitialData();
            StatisticsData = GetStatisticsDataFromDocuments(StatisticsData, documents);
            return StatisticsData;
        }

        private Data InitialData()
        {
            return new Data()
            {
                cols = new List<Col>(),
                rows = new List<Row>()
            };
        }

        private Data GetStatisticsDataFromDocuments(Data data, IEnumerable<OcrDocument> documents)
        {
            data.cols = FillColumns(data.cols);
            data.rows = FillRowsWithDocumentsData(data.rows, documents);
            return data;
        }

        private List<Col> FillColumns(List<Col> cols)
        {
            cols.Add(new Col() {
                         id = "d",
                         label = "Date",
                         type = "string"
                     });
            cols.Add(new Col() {
                         id = "n",
                         label = "Number of Documents",
                         type = "number"
                     });
            return cols;
        }

        private List<Row> FillRowsWithDocumentsData(List<Row> rows, IEnumerable<OcrDocument> documents)
        {
            var dates = new List<string>();
            var occurrences = new List<int>();

            SetDocumentDatesAndOccurrences(documents, dates, occurrences);

            FillRows(rows, dates, occurrences);
            return rows;
        }

        private void SetDocumentDatesAndOccurrences(IEnumerable<OcrDocument> documents, List<string> dates, List<int> occurrences)
        {
            foreach (var doc in documents)
            {
                var date = GetDateInDoc(doc);
                var testIndex = dates.FindIndex(x => x == date );
                if (testIndex != -1)
                {
                    occurrences[testIndex] += 1;
                }
                else
                {
                    dates.Add(date);
                    /* It appears at least once. */
                    occurrences.Add(1);
                }
            }
        }

        private void FillRows(List<Row> rows, List<string> dates, List<int> occurrences)
        {
            for (int i = 0; i < dates.Count; i++)
            {
                var rowContents = new List<C>();
                rowContents.Add(new C() { v = dates[i] });
                rowContents.Add(new C() { v = occurrences[i].ToString() });
                rows.Add(new Row() { c = rowContents });
            }
        }

        private string GetDateInDoc(OcrDocument doc)
        {
            Regex date_regex = new Regex(@"\d{4}-\d{2}-\d{2}T\d{2}:\d{2}:\d{2}.\d{1,7}Z");
            var rawDate = date_regex.Match(doc.Content).ToString();
            var formattedDate = GetDateInYearMonthDayFormat(rawDate);
            return formattedDate;
        }

        private string GetDateInYearMonthDayFormat(string rawDateString)
        {
            /* Date format is: yyyy-mm-dd. */
            return rawDateString.Substring(0, 10);
        }
    }
}
