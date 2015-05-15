using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using HelixSaleService.App_Start;

[assembly: OwinStartup(typeof(WebApiTest.Startup))]

namespace WebApiTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            WebApiConfig.Register(configuration);
            //configuration.Routes.MapHttpRoute("default", "api/{controller}");
            ConfigureAuth(app);
            //app.Use(typeof(HelixSecurityMiddleware));
            app.UseWebApi(configuration);
            
        }
    }
}
