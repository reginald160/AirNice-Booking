

using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirNice.Models.Models
{
   public  class UserRole : BaseModel
    {
       
        public string Title { get; set; }

    }
}
