using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
    public class Booking : BaseModel
    {
        public string Description { get; set; }
        public BookingType BookingType { get; set; }
        public Guid PassengerId { get; set; }
        
        [ForeignKey("PassengerId"), JsonIgnore]
        public virtual Passenger Passenger { get; set; }

    }
}
