using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
    public class CoreProfile : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    
        public string Address { get; set; }
        [JsonIgnore]
        public byte[] picture { get; set; }
        public string Image { get; set; }
        public DateTime DOB { get; set; }
     

        public Guid RoleId { get; set; }
        [ForeignKey("RoleId")]
        [JsonIgnore]
        public UserRole Role { get; set; }

        public bool IsProfiled { get; set; }

        public CoreProfile()
        {
            IsProfiled = false;
        }
    }
}
