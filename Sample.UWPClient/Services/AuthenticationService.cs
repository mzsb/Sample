﻿using Newtonsoft.Json;
using Sample.DTO.Models;
using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Cryptography.Certificates;
using Windows.Web.Http;
using Windows.Web.Http.Filters;
using Windows.Web.Http.Headers;

namespace Sample.UWPClient.Services
{
    public class AuthenticationService : ServiceBase
    {
           public async Task<AppUser> LoginAsync(Login login)
           {
                string result = await HttpRequestWithToken("https://localhost:5001/api/Authentication/Login",
                                                           HttpMethod.Post,
                                                           JsonConvert.SerializeObject(login));


                return JsonConvert.DeserializeObject<AppUser>(result);
           }

            public async Task<AppUser> RegistrationAsync(Registration registration)
            {
                string result = await HttpRequestWithToken("https://localhost:5001/api/Authentication/Registration",
                                                           HttpMethod.Post,
                                                           JsonConvert.SerializeObject(registration));


                return JsonConvert.DeserializeObject<AppUser>(result);
            }
    }
}