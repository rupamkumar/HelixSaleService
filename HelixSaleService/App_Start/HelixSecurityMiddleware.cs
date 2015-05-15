using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;

namespace HelixSaleService.App_Start
{
    public class HelixSecurityMiddleware
    {
        private Func<IDictionary<string, object>, Task> _next;
        public HelixSecurityMiddleware(Func<IDictionary<string,object>,Task> next)
        {
            _next = next;
        }

        public async Task Invoke(IDictionary<string, object> env)
        {
            var context = new OwinContext(env);
            IPrincipal user = context.Request.User;
            await _next(env);
        }
    }
}