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

        public OcrDocument SaveOrUpdate(OcrDocument document)
        {
            var usersList = MongoConn.mongoDB().GetCollection("documents");
            WriteConcernResult result;
            bool hasError = false;
            if(!String.IsNullOrEmpty(document.Id))
            {
                String existingItem = null;
                if(existingItem == null)
                {
                    result = usersList.Insert<OcrDocument>(document);
                    hasError = result.HasLastErrorMessage;
                }
                else
                {
                    IMongoQuery query = Query.EQ("_id", document.Id);
                    IMongoUpdate update = Update.Set("user_id", document.UserId);
                    result = usersList.Update(query, update);
                    hasError = result.HasLastErrorMessage;
                }
            }
            return document;
        }
    }
}
