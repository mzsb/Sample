using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Sample.BLL.AuthenticationModels;
using Sample.BLL.Interfaces;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Sample.BLL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<AppUser> userManager;

        public AuthenticationService(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<AppUser> Login(Login login)
        {
            var appUser = await userManager.FindByNameAsync(login.UserName);

            if (appUser != null && await userManager.CheckPasswordAsync(appUser, login.Password))
            {
                appUser.Role = (await userManager.GetRolesAsync(appUser)).FirstOrDefault();

                var claims = GetClaims(appUser);

                appUser.Token = GenerateToken(claims, login.Secret);

                return appUser;
            }

            return null;
        }

        public async Task<AppUser> Registration(Registration registration)
        {
            if (registration.Password.Equals(registration.PasswordAgain))
            {
                var appUser = new AppUser
                {
                    UserName = registration.UserName,
                    Email = registration.Email,
                };

                var result = await userManager.CreateAsync(appUser, registration.Password);

                if (result.Succeeded)
                {
                    if (appUser.Email.Split("@")[0].ToLower().Contains(registration.Secret.ToLower()))
                    {
                        await userManager.AddToRoleAsync(appUser, "Administrator");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(appUser, "AppUser");
                    }

                    appUser.Role = (await userManager.GetRolesAsync(appUser)).FirstOrDefault();

                    var claims = GetClaims(appUser);

                    appUser.Token = GenerateToken(claims, registration.Secret);

                    return appUser;
                }
            }

            return null;
        }

        private string GenerateToken(IEnumerable<Claim> claims, string secret)
        {
            var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));

            var token = new JwtSecurityToken(
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddSeconds(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(signInKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private List<Claim> GetClaims(AppUser appUser)
        {
            return new List<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, appUser.Role)
            };
        }
    }
}
