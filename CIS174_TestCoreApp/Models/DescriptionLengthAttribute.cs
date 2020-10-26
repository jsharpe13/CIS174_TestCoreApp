using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIS174_TestCoreApp.Models
{
    public class DescriptionLengthAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext ctx)
        {
            string description = (string)value;

            if(description.Length <= 150)
            {
                return ValidationResult.Success;
            }

            string msg = base.ErrorMessage ??
                $"{ctx.DisplayName} must be a valid description";
            return new ValidationResult(msg);
        }
    }
}
