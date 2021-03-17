using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public class Permission : BaseModel
    {
        public string Title { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public string RoleId { get; set; }
        [ForeignKey("RoleId"), JsonIgnore]
        public virtual UserRole Role { get; set; }
    }
}
