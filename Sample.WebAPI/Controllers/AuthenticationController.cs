using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sample.BLL.Interfaces;
using Sample.DTO.Models;
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
        public async Task<ActionResult<AppUser>> Login([FromBody] Login login)
        {
            login.Secret = appSettings.Secret;

            var appUser = await authenticationService.Login(mapper.Map<BLL.AuthenticationModels.Login>(login));

            if(appUser != null)
            {
                var mapped = mapper.Map<AppUser>(appUser);

                mapped.AddMethod<Concert>(MethodType.Get);

                mapped.AddMethod<Concert>(MethodType.Post, mapped.Id.ToString());

                return Ok(mapped);
            }

            return Unauthorized();
        }

        [HttpPost("Registration")]
        public async Task<ActionResult<AppUser>> Registration([FromBody] Registration registration)
        {
            registration.Secret = appSettings.Secret;

            var appUser = await authenticationService.Registration(mapper.Map<BLL.AuthenticationModels.Registration>(registration));

            if (appUser != null)
            {
                var mapped = mapper.Map<AppUser>(appUser);

                mapped.AddMethod<Concert>(MethodType.Get);

                mapped.AddMethod<Concert>(MethodType.Post, mapped.Id.ToString());

                return Ok(mapped);
            }

            return Unauthorized();
        }
    }
}
