using Newtonsoft.Json;
using Sample.DTO.Models;
using Sample.RestHelper.Models;
using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Sample.UWPClient.Helper;

namespace Sample.UWPClient.Services
{
    public class ConcertService : ServiceBase
    {
        public async Task<List<Concert>> GetConcertsAsync(RestMethod restMethod)
        {
            string result = await HttpRequestWithToken(restMethod.Route,
                                                       restMethod.MethodType.ToHttpMethod());

            return JsonConvert.DeserializeObject<List<Concert>>(result) ?? new List<Concert>();
        }

        public async Task<Concert> GetConcertsDetailsAsync(RestMethod restMethod)
        {
            string result = await HttpRequestWithToken(restMethod.Route,
                                                       restMethod.MethodType.ToHttpMethod());

            return JsonConvert.DeserializeObject<Concert>(result);
        }

        public async Task<Concert> CreateConcertAsync(RestMethod restMethod)
        {
            string result = await HttpRequestWithToken(restMethod.Route,
                                                       restMethod.MethodType.ToHttpMethod(),
                                                       restMethod.JsonBody);

            return JsonConvert.DeserializeObject<Concert>(result);
        }
    }
}
