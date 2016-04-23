using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.ViewModel
{
    public class LoginViewModel
    {
        [MinLength(3)]
        [Required]
        public string UserName { get; set; } //Email or userName
        [Required]
        public String Password { get; set; }
    }
}
