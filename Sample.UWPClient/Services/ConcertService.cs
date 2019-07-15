using Newtonsoft.Json;
using Sample.DTO.Models;
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
        public async Task<List<Concert>> GetConcertsAsync(string requestUri)
        {
            string result = await HttpRequestWithToken(requestUri,
                                                       HttpMethod.Get);

            return JsonConvert.DeserializeObject<List<Concert>>(result) ?? new List<Concert>();
        }

        public async Task<Concert> GetConcertsDetailsAsync(string requestUri)
        {
            string result = await HttpRequestWithToken(requestUri,
                                                       HttpMethod.Get);

            return JsonConvert.DeserializeObject<Concert>(result);
        }

        public async Task<Concert> CreateConcertAsync(Concert concert, string requestUri)
        {
            string result = await HttpRequestWithToken(requestUri,
                                                       HttpMethod.Post,
                                                       JsonConvert.SerializeObject(concert));

            return JsonConvert.DeserializeObject<Concert>(result);
        }
    }
}
