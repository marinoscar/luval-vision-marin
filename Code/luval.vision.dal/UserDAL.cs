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
    public class UserDAL : IUserDAO
    {
        public User GetUser(String userId)
        {
            var user = Query<User>.EQ(u => u.id, userId);
            return MongoConn.mongoDB()
                .GetCollection<User>("Users")
                .FindOne(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return MongoConn.mongoDB()
                .GetCollection<User>("Users")
                .FindAll();
        }

        public User SaveOrUpdate(User user)
        {
            var usersList = MongoConn.mongoDB().GetCollection("Users");
            WriteConcernResult result;
            bool hasError = false;
            if(String.IsNullOrEmpty(user.id))
            {
                user.id = ObjectId.GenerateNewId().ToString();
                result = usersList.Insert<User>(user);
                hasError = result.HasLastErrorMessage;
            }
            else
            {
                IMongoQuery query = Query.EQ("_id", user.id);
                IMongoUpdate update = Update.Set("TokenId", user.tokenId);
                result = usersList.Update(query, update);
                hasError = result.HasLastErrorMessage;
            }
            if(!hasError)
            {
                return user;
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
