using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public class Passenger : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public byte[] picture { get; set; }
        public DateTime DOB { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public ApplicationUser User { get; set; }

    }
}
