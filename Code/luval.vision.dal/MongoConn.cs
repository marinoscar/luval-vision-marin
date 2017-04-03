using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;

namespace luval.vision.dal
{
    public class MongoConn
    {
        public static MongoDatabase mongoDB()
        {
            MongoUrl url = new MongoUrl(ConfigurationManager.ConnectionStrings["CelerisMongo"].ConnectionString);
            MongoClient client = new MongoClient(url);
            MongoServer server = client.GetServer();
            return server.GetDatabase("celerisDB");
        }
    }
}
