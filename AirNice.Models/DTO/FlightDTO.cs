using AirNice.Models.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using static AirNice.Models.Enum;

namespace AirNice.Models.DTO
{       

    public class FlightDTO : BaseDTO
    {
        [Globalname, Required]
        public string AirLine { get; set; }
        [Required]
        public string FlightNumber { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTimeOffset? ArrivateDateTime { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTimeOffset? DepartureDateTime { get; set; }
        [DataType(DataType.PhoneNumber), Required]
        public int TotalSeat { get; set; }
        [DataType(DataType.PhoneNumber), Required]
        public int TotalVacantSeat { get; set; }

        public int Seatnumber { get; set; }
        public string CoachSeats { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Faire { get; set; }
        [Required]
        [Display(Name ="Flight Category")]
        public FlightCategory FlightCategory { get; set; }
        public string FlightCategoryToDisplay { get; set; }
        [Required]
        [Display(Name ="Trip Type")]
        public TripType TripTypes { get; set; }
        [Required]
        [Display(Name = "Departure Country")]
        public string DepartureCountry { get; set; }
        [Required]
        [Display(Name = "Departure State")]
        public string DepartureState { get; set; }
        [Required]
        [Display(Name = "Departure City")]
        public string DepartureCity { get; set; }
        [Required]
        [Display(Name = "Arrival Country")]
        public string ArrivalCountry { get; set; }
        [Required]
        [Display(Name = "Arrival State")]
        public string ArrivalState { get; set; }
        [Required]
        [Display(Name = "Arrival City")]
        public string ArrivalCity { get; set; }
        [DataType(DataType.Currency), Required]
        public decimal Price { get; set; }
    }
}
