using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using luval.vision.entity;

namespace luval.vision.dal
{
    public interface IUserDAO
    {
        bool isAuthenticationValid(string email, string tokenId);
        IEnumerable<OcrUser> GetUserList();
        OcrUser GetUser(String userId);
        OcrUser SaveOrUpdate(OcrUser user);
        bool Delete();
    }
}
