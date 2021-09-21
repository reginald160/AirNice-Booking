using AirNice.Models.Helper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirNice.Models.DTO
{
   public class ProfileDTO
    {
        //[GlobalName,Required]
   
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        [DataType(DataType.PhoneNumber), Required]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
 
        public string PassPort { get; set; }
        public string Address { get; set; }
       [FileUpload(new string[] {".jpg",".png",".img"})]
       [Required(ErrorMessage = "Please choose profile image")]

        public IFormFile Image { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DOB { get; set; }
       
    }
}
