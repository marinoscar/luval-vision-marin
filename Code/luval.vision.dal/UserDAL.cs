using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace luval.vision.dal
{
    public class UserDAL : IUserDAO
    {
        public OcrUser GetUser(string email)
        {
            var user = Query<OcrUser>.EQ(u => u.Email, email);
            return MongoConn.mongoDB()
                .GetCollection<OcrUser>("users")
                .FindOne(user);
        }

        public IEnumerable<OcrUser> GetUserList()
        {
            return MongoConn.mongoDB()
                .GetCollection<OcrUser>("users")
                .FindAll();
        }

        public bool isAuthenticationValid(string email, string tokenId)
        {
            return GetUserList().Any(u => u.Email.Equals(email,
                StringComparison.OrdinalIgnoreCase) && u.ApiToken == tokenId);
        }

        public bool isApproved(string email)
        {
            OcrUser user = GetUser(email);

            return user != null && user.IsApproved;
        }

        public bool Delete()
        {
            try
            {
                var userList = MongoConn.mongoDB().GetCollection("users");
                userList.RemoveAll();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public OcrUser SaveOrUpdate(OcrUser user)
        {
            var userList = MongoConn.mongoDB().GetCollection("users");
            WriteConcernResult result;
            var existingItem = GetUser(user.Email);

            if (existingItem == null)
            {
                user.IsApproved = true;
                user.IsEnabled = true;
                user.Role = "User";
                result = userList.Insert<OcrUser>(user);
            }
            else
            {
                user.Id = existingItem.Id;
                result = userList.Save<OcrUser>(user);
            }
            return user;
        }
    }
}
