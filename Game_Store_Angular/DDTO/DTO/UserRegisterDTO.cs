using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.DDTO.DTO
{
    public class UserRegisterDTO
    {
        [Required(ErrorMessage = "Email is required filds")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Passwprd is required filds")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Full name is required filds")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Phone is required filds")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is required filds")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Age is required filds")]
        [Range(15, 100, ErrorMessage = "Age range from 15 to 100")]
        public int Age { get; set; }
    }
}
