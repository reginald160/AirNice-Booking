

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public  class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            IsProfiled = false;
        }
        [NotMapped]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
        public string Imageurl { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DOB { get; set; }
        public bool IsProfiled { get; set; }
    }
}
