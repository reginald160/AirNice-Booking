using Microsoft.AspNetCore.Mvc.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AirNice.Models.Helper
{
  
    public  class Globalname : ValidationAttribute
    {
        public bool _IsRequired { get; set; }
        public Globalname()
        {
            
        }
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
            //if (_IsRequired.Equals(true) && value.ToString().Equals(String.Empty))
            //{
             
            //    return new ValidationResult($" The {validationContext.DisplayName} field is required");
            //}


            return ValidationResult.Success;
        }
    }


}
