using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Sample.DAL.Context;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sample.DAL
{
    public class SeedDatabase
    {
        public static async void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<SampleContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            context.Database.EnsureCreated();

            if (!context.AppUsers.Any())
            {
                AppUser appUser = new AppUser()
                {
                    Email = "sample@sample.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Sam_Ple"
                };

                await userManager.CreateAsync(appUser, "Password@123");
            }

            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                var adminRole = new IdentityRole<Guid>("Administrator");
                await roleManager.CreateAsync(adminRole);
            }

            if (!await roleManager.RoleExistsAsync("AppUser"))
            {
                var pilotRole = new IdentityRole<Guid>("AppUser");
                await roleManager.CreateAsync(pilotRole);
            }
        }
    }
}
