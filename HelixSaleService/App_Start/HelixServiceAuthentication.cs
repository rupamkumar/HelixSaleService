using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;

namespace HelixSaleService.App_Start
{
    public class HelixServiceAuthentication :IHttpModule, IDisposable
    {

        private const string Realm = "Helix";
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += AuthenticateRequests;
            context.EndRequest += OnApplicationEndRequest;
        }

        private void OnApplicationEndRequest(object sender, EventArgs e)
        {
            HttpResponse resp = HttpContext.Current.Response;
            if(resp.StatusCode ==401)
            {
                resp.Headers.Add("www-Authenticate", string.Format("Basic realm=\"{0}\"", Realm));
            }
        }

        private void AuthenticateRequests(object sender, EventArgs e)
        {
            string authHeader = HttpContext.Current.Request.Headers["Authorization"];
            if(authHeader != null)
            {
                AuthenticationHeaderValue authHeaderVal = AuthenticationHeaderValue.Parse(authHeader);
                if ((authHeaderVal.Parameter != null) && (authHeaderVal.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase)))
                {
                    //byte[] unencoded = Convert.FromBase64String(authHeaderVal.Parameter);
                    //string userpw = Encoding.GetEncoding("iso-8859-1").GetString(unencoded);
                    //string[] creds = userpw.Split(':');
                    AuthenticateUser(authHeaderVal.Parameter);
                }
            }
        }

        private static void AuthenticateUser(string credentials)
        {
            try
            {
                var encoding = Encoding.GetEncoding("iso-8859-1");
                credentials = encoding.GetString(Convert.FromBase64String(credentials));
                int separator = credentials.IndexOf(':');
                string username = credentials.Substring(0, separator);
                string password = credentials.Substring(separator + 1);
                if (CheckCredentials(username, password))
                {
                    var identity = new GenericIdentity(username);
                    SetPrincipal(new GenericPrincipal(identity, null));
                }
                else
                {
                    //Invalid username or password.
                    HttpContext.Current.Response.StatusCode = 401;
                }
            }
            catch(FormatException)
            {
                //Credentials were not formatted correctly
                HttpContext.Current.Response.StatusCode = 401;
            }
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if(HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

        

        private static bool CheckCredentials(string username, string password)
        {
            return username == "user" && password == "password";
        }

        public void Dispose()
        {
        }
    }
}