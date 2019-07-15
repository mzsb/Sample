using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;

namespace Sample.UWPClient.Services
{
    public abstract class ServiceBase
    {
        public static string Token { get; set; } = string.Empty;

        protected async Task<string> HttpRequestWithToken(string url, Windows.Web.Http.HttpMethod method, string body = "")
        {
            var filter = new HttpBaseProtocolFilter();
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);

            using (var httpClient = new Windows.Web.Http.HttpClient(filter))
            {
                Windows.Web.Http.HttpResponseMessage response;
                try
                {
                    var request = new Windows.Web.Http.HttpRequestMessage(method, new Uri(url));
                    if (Token != string.Empty)
                    {
                        request.Headers.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
                    }
                    if (body != string.Empty)
                    {
                        request.Content = new Windows.Web.Http.HttpStringContent(body);
                        request.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
                    }
                    response = await httpClient.SendRequestAsync(request);
                    var content = await response.Content.ReadAsStringAsync();
                    return content;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
        }
    }
}
