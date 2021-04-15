using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public  class AirPort : BaseModel
    {
        public string Name { get; set; }

        public string Abbreviation { get; set; }
        public Guid? LocationId { get; set; }
        [ForeignKey("LocationId"), JsonIgnore]
        public Location Location  { get; set; }



    }
}
