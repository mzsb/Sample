using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sample.BLL.Interfaces;
using Sample.BLL.Services;
using Sample.WebAPI.Dtos;

namespace Sample.WebAPI.Controllers
{
    [Authorize]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserService service;
        private IMapper mapper;

        public UserController(IUserService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var appUsers = await service.GetUsersAsync();

            List<AppUser> mapped = mapper.Map<List<AppUser>>(appUsers);

            return mapped;
        }
    }
}
