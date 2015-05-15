using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Security.Principal;

namespace HelixSaleService.App_Start
{
    public class ServiceAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {
        public async Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken  tokencancel )
        {        
            System.Security.Principal.IPrincipal  user = context.ActionContext.RequestContext.Principal;
        }

        public async Task ChallengeAsync(HttpAuthenticationChallengeContext context,System.Threading.CancellationToken tokencancel )
        {

        }

        public bool AllowMultiple
        {
            get { return false; }
        }
    }
}