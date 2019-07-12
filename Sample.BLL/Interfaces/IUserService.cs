using Sample.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.BLL.Interfaces
{
    public interface IUserService
    {
        Task<List<AppUser>> GetUsersAsync();
    }
}
