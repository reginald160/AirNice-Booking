using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
    public class BaseModel
    {
     
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool IsNewRecord { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public string CreateById { get; set; }
        [ForeignKey("CreateById"), JsonIgnore]
        public ApplicationUser CreatedBy { get; set; }
        public string EditedById { get; set; }

        [ForeignKey("EditedById"), JsonIgnore]
        public ApplicationUser EdityBy { get; set; }
    }
}
