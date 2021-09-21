using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public abstract class UserProfile : BaseModel
    {
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
		public bool IsActive { get; set; }
		public string Image { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [JsonIgnore]
        public ApplicationUser User { get; set; }
        public bool IsProfiled { get; set; }

        public UserProfile()
        {
            IsProfiled = false;
        }

    }
}
