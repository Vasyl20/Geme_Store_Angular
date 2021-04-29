using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Game_Store_Angular.DDTO.DataAccess.Entity
{
    public class User : IdentityUser
    {
        [Required(ErrorMessage = "Full name is required field")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Adress name is required field")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Age name is required field")]
        public int Age { get; set; }
    }
}
