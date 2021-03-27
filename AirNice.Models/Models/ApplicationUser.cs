

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
        public ApplicationUser()
        {
            IsSuccessful = false;
        }
        public string RoleTitle { get; set; }
       [NotMapped]
        public string Passcode { get; set; }
        public bool IsSuccessful { get; set; }

    }
}
