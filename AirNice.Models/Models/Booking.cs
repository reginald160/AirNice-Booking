using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;
using static AirNice.Models.Enum;

namespace AirNice.Models.Models
{
    public class Booking : BaseModel
    {
        public string Description { get; set; }
        public BookingType BookingType { get; set; }
        public string BookingTypeToDisplay { get; set; }
        public Guid PassengerId { get; set; }
        [ForeignKey("PassengerId"), JsonIgnore]
        public virtual Passenger Passenger { get; set; }
        public Guid FlightId { get; set; }
        [ForeignKey("PassengerId"), JsonIgnore]
        public Flight Flight { get; set; }
        public int NumberOfChildren { get; set; }
        [NotMapped]
        public List<int> Availableseats { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfInfant { get; set; }
        public TripType TripeType { get; set; }
        public string TripeTypeToDisplay { get; set; }
        public decimal Price { get; set; }

    }
}
