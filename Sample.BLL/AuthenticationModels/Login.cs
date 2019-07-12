using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.BLL.AuthenticationModels
{
    public class Login
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Secret { get; set; }
    }
}
