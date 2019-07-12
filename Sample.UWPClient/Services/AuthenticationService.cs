using Newtonsoft.Json;
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

namespace Sample.UWPClient.Services
{
    public class AuthenticationService : ServiceBase
    {
           public async Task<DataFrame<AppUser>> LoginAsync(Login login)
           {
                string result = await HttpRequestWithToken("https://localhost:5001/api/Authentication/Login",
                                                           Windows.Web.Http.HttpMethod.Post,
                                                           JsonConvert.SerializeObject(login));


                return JsonConvert.DeserializeObject<DataFrame<AppUser>>(result);
           }

            public async Task<AppUser> RegistrationAsync(Registration registration)
            {
                string result = await HttpRequestWithToken("https://localhost:5001/api/Authentication/Registration",
                                                           Windows.Web.Http.HttpMethod.Post,
                                                           JsonConvert.SerializeObject(registration));


                return JsonConvert.DeserializeObject<AppUser>(result);
            }
    }
}
