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
        OcrUser SaveOrUpdate(OcrUser user);
        IEnumerable<OcrUser> GetUsers();
        OcrUser GetUser(String userId);

    }
}
