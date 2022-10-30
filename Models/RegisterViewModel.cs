using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi_Shop.Models
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress,ErrorMessage ="Invalid Email")]
        
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
       [RegularExpression(@"^01[0125][0-9]{8}$", ErrorMessage ="Invalid Phone Number")]
        public string Phone { get; set; }

        [Required]
        public string Country { get; set; }
    }
}
