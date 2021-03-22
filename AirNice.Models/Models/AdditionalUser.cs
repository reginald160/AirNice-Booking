using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AirNice.Models.Models
{
    public class AdditionalUser : BaseModel
    {
      
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
