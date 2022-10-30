using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi__Shop.Models
{
    public class RoleNameChecking : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && value.ToString()=="Customer" || value.ToString()=="Admin")
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Role Name Must Be Customer or Admin");
        }
    }
}
