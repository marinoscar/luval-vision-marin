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

        public bool Delete(OcrDocument document)
        {
            try
            {
                var documentsList = MongoConn.mongoDB().GetCollection("documents");
                IMongoQuery query = Query.EQ("_id", document.Id);
                documentsList.Remove(query);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public OcrDocument SaveOrUpdate(OcrDocument document)
        {
            var documentsList = MongoConn.mongoDB().GetCollection("documents");
            WriteConcernResult result;
            if(!String.IsNullOrEmpty(document.Id))
            {
                var existingItem = GetProcessResult(document.Id);
                if (existingItem == null)
                {
                    result = documentsList.Insert<OcrDocument>(document);
                }
                else
                {
                    IMongoQuery query = Query.EQ("_id", document.Id);
                    IMongoUpdate update = Update.Set("user_id", document.UserId)
                        .Set("duration_inms", document.DurationInMs)
                        .Set("process_result", document.Content);
                    result = documentsList.Update(query, update);
                }
            }
            return document;
        }
    }
}
