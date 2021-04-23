

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirNice.Models.Models
{
   public  class UserRole : IdentityUserRole
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }

    }
}
