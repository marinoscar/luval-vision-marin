using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using luval.vision.entity;
using luval.vision.dal;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        private UserDAL userDAL;

        public UserController()
        {
            userDAL = new UserDAL();
        }

        public IHttpActionResult Post(OcrUser user)
        {
            try
            {
                OcrUser userResult = userDAL.SaveOrUpdate(user);
                if(!userResult.Equals(null))
                {
                    return Ok(userResult);
                }
                return Content(HttpStatusCode.InternalServerError, "The user couldn't be registered");
            }
            catch (System.Exception e)
            {
                return Content(HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
