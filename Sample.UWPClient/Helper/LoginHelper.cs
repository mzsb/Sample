using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Sample.UWPClient.Helper
{
    public static class LoginHelper
    {
        public static void Reset(this Login login)
        {
            foreach (PropertyInfo prop in login.GetType().GetProperties())
            {
                prop.SetValue(login, string.Empty);
            }
        }

        public static async Task<bool> IsValid(this Login login)
        {
            if (string.IsNullOrEmpty(login.UserName) ||
                string.IsNullOrWhiteSpace(login.UserName))
            {
                await new MessageDialog("Érvénytelen felhasználónév!").ShowAsync();

                return false;
            }
            else
            if (string.IsNullOrEmpty(login.Password) ||
                string.IsNullOrWhiteSpace(login.Password))
            {
                await new MessageDialog("Érvénytelen jelszó!").ShowAsync();

                return false;
            }

            return true;
        }
    }
}
