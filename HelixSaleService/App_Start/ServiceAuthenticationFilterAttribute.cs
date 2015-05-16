using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Filters;
using System.Security.Principal;
using System.Web.Http.Results;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Text;
using System.Security.Cryptography;
using System.Net.Http;
using System.Configuration;

////http://bitoftech.net/2014/12/15/secure-asp-net-web-api-using-api-key-authentication-hmac-authentication/



namespace HelixSaleService.App_Start
{
    public class ServiceAuthenticationFilterAttribute : Attribute, IAuthenticationFilter
    {
        private string APPId = ConfigurationManager.AppSettings["APPId"];
        private string APIKey = ConfigurationManager.AppSettings["APIKey"];
        private static Dictionary<string, string> allowedApps = new Dictionary<string, string>();        
        private readonly string authenticationscheme = "Hell";

        public ServiceAuthenticationFilterAttribute()
        {
            if (allowedApps.Count == 0)
            {
                allowedApps.Add(APPId, APIKey);
            }
        }

        public  Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken  tokencancel )
        {
            var req = context.Request;
            if (req.Headers.Authorization != null && authenticationscheme.Equals(req.Headers.Authorization.Scheme, StringComparison.OrdinalIgnoreCase))
            {
                string authHeader = req.Headers.Authorization.Parameter;
                var authrizationarray = GetAuthrizationHeaderValues(authHeader);
                if (authrizationarray != null)
                {
                    var APPId = authrizationarray[0];
                    var incomingBase64Signature = authrizationarray[1];
                    var requestTimeStamp = authrizationarray[2];
                    var isValid = isValidRequest(req, APPId, incomingBase64Signature, requestTimeStamp);
                    if (isValid.Result)
                    {
                        var currentPrincipal = new GenericPrincipal(new GenericIdentity(APPId), null);
                        context.Principal = currentPrincipal;
                    }
                    else
                    {
                        context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                    }
                }
                else
                {
                    context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
                }
            }
            else
            {
                context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[0], context.Request);
            }
            return Task.FromResult(0);
        }

        private async Task<bool> isValidRequest(System.Net.Http.HttpRequestMessage req, string AppId, string incomingBase64Signature, string requestTimeStamp)
        {
            string requestContentBase64String = "";
            string requestUri = req.RequestUri.AbsoluteUri.ToLower();
            string requestHttpMethod = req.Method.Method;

            if (!allowedApps.ContainsKey(APPId))
            {
                return false;
            }

            var sharedKey = allowedApps[APPId];
            
           
            requestContentBase64String = sharedKey ;

            string data = String.Format("{0}{1}{2}{3}{4}", AppId, requestUri, requestHttpMethod, requestTimeStamp, requestContentBase64String);

            var secretKeyBytes = Convert.FromBase64String(sharedKey);

            byte[] signature = Encoding.UTF8.GetBytes(data);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] signatureBytes = hmac.ComputeHash(signature);
                string requestSignature = Convert.ToBase64String(signatureBytes);

                return (incomingBase64Signature.Equals(requestSignature, StringComparison.Ordinal));
            } 
        }

     
        private string[] GetAuthrizationHeaderValues(string authHeader)
        {
            var credentialArray = authHeader.Split(':');
            if(credentialArray.Length ==3)
            {
                return credentialArray;
            }
            else
            {
                return  null;
            }
        }

        public  Task ChallengeAsync(HttpAuthenticationChallengeContext context,System.Threading.CancellationToken tokencancel )
        {
            context.Result = new HelixSecurityMiddleware(context.Result);
            return Task.FromResult(0);
        }

        public bool AllowMultiple
        {
            get { return false; }
        }
    }

   
}