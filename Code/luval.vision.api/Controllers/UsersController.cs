using luval.vision.entity;
using luval.vision.bll;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Net;

namespace luval.vision.api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        private UserLogic userLogic;

        public UsersController()
        {
            userLogic = new UserLogic();
        }

        public IHttpActionResult Get(string userEmail)
        {
            try
            {
                if (String.IsNullOrEmpty(userEmail))
                {
                    return BadRequest();
                }
                OcrUser user = userLogic.GetUser(userEmail);

                if (user == null)
                {
                    return NotFound();
                }

                return Ok(user);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, exception.ToString());
            }
        }

        public IHttpActionResult Post(OcrUser request)
        {
            try
            {
                if (String.IsNullOrEmpty(request.Email) ||
                    String.IsNullOrEmpty(request.Name) ||
                    String.IsNullOrEmpty(request.ApiToken) ||
                    String.IsNullOrEmpty(request.UserId))
                {
                    return BadRequest();
                }
                OcrUser user = userLogic.SaveOrUpdate(request.ApiToken, request.Email, request.Name, request.UserId);

                return Ok(user);
            }
            catch (Exception exception)
            {
                return Content(HttpStatusCode.InternalServerError, exception.ToString());
            }
        }
    }
}
