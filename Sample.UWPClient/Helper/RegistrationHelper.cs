using Sample.DTO.Models;
using Sample.UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace Sample.UWPClient.Helper
{
    public static class RegistrationHelper
    {
        public static void Reset(this Registration registration)
        {
            foreach (PropertyInfo prop in registration.GetType().GetProperties())
            {
                prop.SetValue(registration, string.Empty);
            }
        }

        public static async Task<bool> IsValid(this Registration registration)
        {
            if (string.IsNullOrEmpty(registration.UserName) ||
                string.IsNullOrWhiteSpace(registration.UserName))
            {
                await new MessageDialog("Érvénytelen felhasználónév!").ShowAsync();

                return false;
            }
            else
            if (string.IsNullOrEmpty(registration.Email) ||
                string.IsNullOrWhiteSpace(registration.Email) ||
                !Regex.IsMatch(registration.Email, @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))
            {
                await new MessageDialog("Érvénytelen email cím!").ShowAsync();

                return false;
            }
            else
            if (string.IsNullOrEmpty(registration.Password) ||
                string.IsNullOrWhiteSpace(registration.Password))
            {
                await new MessageDialog("Érvénytelen jelszó!").ShowAsync();

                return false;
            }
            else
            if (string.IsNullOrEmpty(registration.PasswordAgain) ||
                string.IsNullOrWhiteSpace(registration.PasswordAgain) ||
                !registration.Password.Equals(registration.PasswordAgain))
            {
                await new MessageDialog("Jelszó és ismétlése nem egyezik!").ShowAsync();

                return false;
            }

            return true;
        }
    }
}
