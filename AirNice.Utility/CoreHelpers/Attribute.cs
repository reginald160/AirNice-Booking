using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AirNice.Utility.CoreHelpers
{
  
    public  class Globalname : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value?.ToString()[0] != value?.ToString().ToUpper()[0])
            {
                return new ValidationResult("Value must start with capital letter");
            }
            if (value.ToString().Length > 20)
            {
                return new ValidationResult("Value must not be more more than 15 letters");
            }
           
            return ValidationResult.Success;
        }
    }


}
