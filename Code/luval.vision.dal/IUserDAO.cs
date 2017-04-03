using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;
using MongoDB.Bson;

namespace luval.vision.dal
{
    public interface IUserDAO
    {
        User SaveOrUpdate(User user);
        IEnumerable<User> GetUsers();
        User GetUser(String userId);

    }
}
