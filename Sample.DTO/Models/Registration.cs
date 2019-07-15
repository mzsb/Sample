using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.DTO.Models
{
    public class Registration
    {
        [Required(ErrorMessage = "Username is required", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required", AllowEmptyStrings = false)]
        public string Password { get; set; }

        [Required(ErrorMessage = "PasswordAgain is required", AllowEmptyStrings = false)]
        public string PasswordAgain { get; set; }

        public string Secret { get; set; }
    }
}
