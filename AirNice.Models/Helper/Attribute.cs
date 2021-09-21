using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Providers.Entities;

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

    public class PhoneNumber : ValidationAttribute
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
            //if (_IsRequired.Equals(true) && value.ToString().Equals(String.Empty))
            //{

            //    return new ValidationResult($" The {validationContext.DisplayName} field is required");
            //}


            return ValidationResult.Success;
        }
    }

    public class FileUpload : ValidationAttribute
    {
        private readonly string[] _extensions;
        public FileUpload(string[] extensions)
        {
            _extensions = extensions;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            var extension = Path.GetExtension(file.FileName);
            if (file != null)
            {
                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage(extension));
                }
            }

            return ValidationResult.Success;
        }
        public string GetErrorMessage(string extension)
        {
            return $"The .{extension} format of the file you are trying to upload is not allowed!";
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }
    }

}
