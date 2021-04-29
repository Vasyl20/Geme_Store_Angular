using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.DDTO.DTO
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "Email is required filds")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwprd is required filds")]
        public string Password { get; set; }
    }
}
