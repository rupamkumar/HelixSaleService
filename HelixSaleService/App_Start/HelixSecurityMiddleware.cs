using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace HelixSaleService.App_Start
{
    public class HelixSecurityMiddleware : IHttpActionResult
    {
        //private Func<IDictionary<string, object>, Task> _next;
        //public HelixSecurityMiddleware(Func<IDictionary<string,object>,Task> next)
        //{
        //    _next = next;
        //}

        //public async Task Invoke(IDictionary<string, object> env)
        //{
        //    var context = new OwinContext(env);
        //    IPrincipal user = context.Request.User;
        //    await _next(env);
        //}

        private readonly string authenticationScheme = "Hell";
        private readonly IHttpActionResult _next;

        public HelixSecurityMiddleware(IHttpActionResult next)
        {
            _next = next;
        }

        public async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken )
        {
            var response = await _next.ExecuteAsync(cancellationToken);
            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized )
            {
                response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(authenticationScheme));
            }
            return response;
        }
    }
}