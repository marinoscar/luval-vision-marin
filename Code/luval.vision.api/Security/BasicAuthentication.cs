using luval.vision.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace luval.vision.api.Security
{
    public class BasicAuthentication: AuthorizationFilterAttribute
    {
        private UserLogic userLogic;

        public BasicAuthentication()
        {
            userLogic = new UserLogic();
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request
                    .CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                string[] emailTokenIdArray = decodedAuthenticationToken.Split(':');
                string email = emailTokenIdArray[0];
                string tokenId = emailTokenIdArray[1];

                if (userLogic.isAuthenticationValid(email, tokenId))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(email), null);
                }
                else
                {
                    actionContext.Response = actionContext.Request
                        .CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}