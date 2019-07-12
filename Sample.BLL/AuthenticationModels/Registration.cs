using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.BLL.AuthenticationModels
{
    public class Registration
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordAgain { get; set; }
        public string Secret { get; set; }
    }
}
