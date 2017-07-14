using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using Newtonsoft.Json;

using luval.vision.entity;

namespace luval.vision.dal
{
    public class DocumentDAL : IDocumentDAO
    {
        public IEnumerable<OcrDocument> GetProcessResultByUserId(String userId)
        {
            var document = Query<OcrDocument>.EQ(u => u.UserId, userId);
            return MongoConn.mongoDB()
                .GetCollection<OcrDocument>("documents")
                .Find(document);
        }

        public IEnumerable<DocumentStatistics> GetDocumentStatisticsByUserId(string userId, string date)
        {
            var document = Query<OcrDocument>.EQ(u => u.UserId, userId);
            var collection = MongoConn.mongoDB()
                .GetCollection<OcrDocument>("documents");
            var filteredResult = from e in collection.AsQueryable()
                                 where e.UserId == userId && e.Date >= DateTime.Parse(date) && e.Date < DateTime.Parse(date).AddMonths(1)
                                 select new { date = e.Date.ToString("yyyy-MM-dd") };
            var group = filteredResult.AsEnumerable().GroupBy(x => x.date).Select(y => new DocumentStatistics { Date = y.Key, Ocurrences = y.Count() });
            return group;
        }

        public OcrDocument GetProcessResult(String id)
        {
            var document = Query<OcrDocument>.EQ(u => u.Id, id);
            return MongoConn.mongoDB()
                .GetCollection<OcrDocument>("documents")
                .FindOne(document);
        }

        public IEnumerable<OcrDocument> GetProcessResults()
        {
            return MongoConn.mongoDB()
                .GetCollection<OcrDocument>("documents")
                .FindAll();
        }

        public bool DeleteByDocument(OcrDocument document)
        {
            bool retVal;
            try
            {
                var documentsList = MongoConn.mongoDB().GetCollection("documents");
                IMongoQuery query = Query.EQ("_id", document.Id);
                documentsList.Remove(query);
                retVal = true;
            }
            catch
            {
                retVal = false;
            }
            return retVal;
        }

        public OcrDocument Save(OcrDocument document)
        {
            if (isValidDocumentId(document.Id))
            {
                var documentsList = MongoConn.mongoDB().GetCollection("documents");
                WriteConcernResult result = documentsList.Insert<OcrDocument>(document);
            }
            return document;
        }

        private bool isValidDocumentId(string documentId)
        {
            return !String.IsNullOrEmpty(documentId);
        }
    }
}
