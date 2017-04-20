using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using System.Net;
using System.Web.Http;
using Newtonsoft.Json;

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
            try
            {
                var documentsList = MongoConn.mongoDB().GetCollection("documents");
                IMongoQuery query = Query.EQ("_id", document.Id);
                documentsList.Remove(query);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OcrDocument Save(OcrDocument document)
        {
            var documentsList = MongoConn.mongoDB().GetCollection("documents");
            WriteConcernResult result;
            if(!String.IsNullOrEmpty(document.Id))
            {
                result = documentsList.Insert<OcrDocument>(document);
            }
            return document;
        }
    }
}
