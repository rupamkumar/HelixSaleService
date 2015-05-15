using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Http;

namespace HelixSaleService.App_Start
{
    public class ServiceAuthorizationFilterAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            IPrincipal user = actionContext.RequestContext.Principal;
            return base.IsAuthorized(actionContext);
        }
    }
}