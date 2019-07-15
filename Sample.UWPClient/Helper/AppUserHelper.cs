using Sample.DTO.Models;
using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.UWPClient.Helper
{
    public static class AppUserHelper
    {
        public static bool IsInRole(this AppUser appUser, string role)
        {
            return appUser.Role.Equals(role);
        }
    }
}
