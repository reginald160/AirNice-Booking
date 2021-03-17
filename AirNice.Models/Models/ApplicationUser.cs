
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public  class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string RoleId { get; set; }
        [ForeignKey("RoleId"), JsonIgnore]
        public UserRole Role { get; set; }
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }

    }
}
