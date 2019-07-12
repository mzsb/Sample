using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sample.BLL.AuthenticationModels;
using Sample.BLL.Interfaces;
using Sample.DAL.Entities;
using Sample.RestHelper.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sample.WebAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/Authentication")]
    public class AuthenticationController : Controller
    {
        private readonly IAuthenticationService authenticationService;
        private readonly AppSettings appSettings;
        private readonly IMapper mapper;

        public AuthenticationController(IAuthenticationService authenticationService,
                                        AppSettings appSettings, 
                                        IMapper mapper)
        {
            this.authenticationService = authenticationService;
            this.appSettings = appSettings;
            this.mapper = mapper;
        }

        [HttpPost("Login")]
        public async Task<ActionResult<DataFrame<Dtos.AppUser>>> Login([FromBody] Dtos.Login login)
        {
            login.Secret = appSettings.Secret;

            var appUser = await authenticationService.Login(mapper.Map<Login>(login));

            if(appUser != null)
            {
                DataFrame<Dtos.AppUser> dataFrame = new DataFrame<Dtos.AppUser>();

                var mapped = mapper.Map<Dtos.AppUser>(appUser);

                dataFrame.DataObject = mapped;

                dataFrame.RestMetas.Add(new RestMeta { Method = "GetConcerts", Ref = "https://localhost:5001/api/Concert" });

                dataFrame.RestMetas.Add(new RestMeta { Method = "CreateConcert", Ref = $"https://localhost:5001/api/Concert/{mapped.Id}" });

                return Ok(dataFrame);
            }

            return Unauthorized();
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<DataFrame<Dtos.AppUser>>> Registration([FromBody] Dtos.Registration registration)
        {
            registration.Secret = appSettings.Secret;

            var appUser = await authenticationService.Registration(mapper.Map<Registration>(registration));

            if (appUser != null)
            {
                DataFrame<Dtos.AppUser> dataFrame = new DataFrame<Dtos.AppUser>();

                var mapped = mapper.Map<Dtos.AppUser>(appUser);

                dataFrame.DataObject = mapped;

                dataFrame.RestMetas.Add(new RestMeta { Method = "GetConcerts", Ref = "https://localhost:5001/api/Concert" });

                dataFrame.RestMetas.Add(new RestMeta { Method = "CreateConcert", Ref = $"https://localhost:5001/api/Concert/{mapped.Id}" });

                return Ok(dataFrame);
            }

            return Unauthorized();
        }
    }
}
