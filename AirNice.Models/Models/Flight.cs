using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Models.Enum;

namespace AirNice.Models.Models
{
   public class Flight : BaseModel
    {
        public Flight()
        {
            IsAvailable = false;
        }
        public string AirLine { get; set; }
        public string FlightNumber { get; set; }

        public DateTimeOffset? ArrivateDateTime  { get; set; }

        public DateTimeOffset? DepartureDateTime { get; set; }

        public FlightCategory FlightCategory { get; set; }
        public string FlightCategoryToDisplay { get; set; }

        public int TotalSeat { get; set; }
        public int TotalVacantSeat { get; set; }

        public int Seatnumber { get; set; }
        public string CoachSeats { get; set; }
        public bool IsAvailable { get; set; }
        public string TypeOfPlane { get; set; }
        public decimal Faire { get; set; }
        public string TripTypes { get; set; }
        public string DepartureCountry { get; set; }
        public string DepartureState { get; set; }
        public string DepartureCity { get; set; }

        public string ArrivalCountry { get; set; }
        public string ArrivalState { get; set; }
        public string ArrivalCity { get; set; }

        public decimal Price { get; set; }

    }
}
