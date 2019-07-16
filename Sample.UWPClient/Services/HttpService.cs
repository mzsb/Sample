using Sample.RestHelper.Models;
using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;
using Sample.UWPClient.Helper;
using Newtonsoft.Json;
using Windows.Web.Http;

namespace Sample.UWPClient.Services
{
    public class HttpService
    {
        public static string Token { get; set; } = string.Empty;

        public async Task<T> HttpRequestAsync<T>(RestMethod restMethod)
        {
            var filter = new HttpBaseProtocolFilter();

            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);

            using (var httpClient = new Windows.Web.Http.HttpClient(filter))
            {
                var request = new Windows.Web.Http.HttpRequestMessage(restMethod.MethodType.ToHttpMethod(), 
                                                                        new Uri(restMethod.Route));
                if (!string.IsNullOrEmpty(Token))
                {
                    request.Headers.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
                }

                if (!string.IsNullOrEmpty(restMethod.JsonBody))
                {
                    request.Content = new Windows.Web.Http.HttpStringContent(restMethod.JsonBody);
                    request.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
                }

                Windows.Web.Http.HttpResponseMessage response;

                response = await httpClient.SendRequestAsync(request);

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public async Task<T> HttpRequestAsync<T>(string route, HttpMethod httpMethod, string jsonBody = "")
        {
            var filter = new HttpBaseProtocolFilter();

            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Expired);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.Untrusted);
            filter.IgnorableServerCertificateErrors.Add(ChainValidationResult.InvalidName);

            using (var httpClient = new Windows.Web.Http.HttpClient(filter))
            {
                var request = new Windows.Web.Http.HttpRequestMessage(httpMethod,
                                                                        new Uri(route));
                if (!string.IsNullOrEmpty(Token))
                {
                    request.Headers.Authorization = new HttpCredentialsHeaderValue("Bearer", Token);
                }

                if (!string.IsNullOrEmpty(jsonBody))
                {
                    request.Content = new Windows.Web.Http.HttpStringContent(jsonBody);
                    request.Content.Headers.ContentType = new HttpMediaTypeHeaderValue("application/json");
                }

                Windows.Web.Http.HttpResponseMessage response;

                response = await httpClient.SendRequestAsync(request);

                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
