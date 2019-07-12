using Newtonsoft.Json;
using Sample.RestHelper.Models;
using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Sample.UWPClient.Services
{
    public class ConcertService : ServiceBase
    {
        public async Task<List<Concert>> GetConcertsAsync(RestMeta restMeta)
        {
            string result = await HttpRequestWithToken(restMeta.Ref,
                                                       HttpMethod.Get);

            return JsonConvert.DeserializeObject<List<Concert>>(result) ?? new List<Concert>();
        }

        public async Task<Concert> GetConcertsDetailsAsync(RestMeta restMeta)
        {
            string result = await HttpRequestWithToken(restMeta.Ref,
                                                       HttpMethod.Get);

            return JsonConvert.DeserializeObject<Concert>(result);
        }

        public async Task<Concert> CreateConcertAsync(Concert concert, RestMeta restMeta)
        {
            string result = await HttpRequestWithToken(restMeta.Ref,
                                                       HttpMethod.Post,
                                                       JsonConvert.SerializeObject(concert));

            return JsonConvert.DeserializeObject<Concert>(result);
        }
    }
}
