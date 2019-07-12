using Microsoft.EntityFrameworkCore;
using Sample.BLL.Interfaces;
using Sample.DAL.Context;
using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly SampleContext context;

        public UserService(SampleContext context)
        {
            this.context = context;
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            return await context.AppUsers
                                .AsNoTracking()
                                .ToListAsync();
        }
    }
}
