using Sample.BLL.AuthenticationModels;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.BLL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<AppUser> Login(Login login);
        Task<AppUser> Registration(Registration registration);
    }
}
