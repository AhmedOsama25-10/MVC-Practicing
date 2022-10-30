using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class AssigningUserToRoleByUserName
    {
        [Required]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        [RoleNameChecking]
        public string RoleName { get; set; }
    }
}
