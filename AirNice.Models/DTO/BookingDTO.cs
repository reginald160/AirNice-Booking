using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;
using static AirNice.Models.Enum;

namespace AirNice.Models.DTO
{
    public class BookingDTO : BaseDTO
    {
        public string Description { get; set; }
        public BookingType BookingType { get; set; }
        public string BookingTypeToDisplay { get; set; }
        public Guid PassengerId { get; set; }
        public Guid FlightId { get; set; }
        [JsonIgnore]
        public List<int> Availableseats { get; set; }
        public int NumberOfAdult { get; set; }
        public int NumberOfChildren { get; set; }
        public int NumberOfInfant { get; set; }
        [Display(Name ="Trip Type")]
        public TripType TripeType { get; set; }
        public string TripeTypeToDisplay { get; set; }
        public string Trip { get; set; }
        public decimal Price { get; set; }
    }
}
