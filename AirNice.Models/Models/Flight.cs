using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Models.Enum;

namespace AirNice.Models.Models
{
   public class Flight : BaseModel2
    {
        public Flight()
        {
            IsAvailable = false;
        }
        public string AirLine { get; set; }
        public string FlightNumber { get; set; }
        
        public DateTime? ArrivalDate { get; set; }

        public DateTime? DepartureDate { get; set; }

        public FlightCategory? FlightCategory { get; set; }
        public string FlightCategoryToDisplay { get; set; }
        public bool? IsAvailable { get; set; }
        public string Status { get; set; }
        public decimal Price { get; set; }
        public int? PlaneID { get; set; }
        public virtual Plane Plane { get; set; }
        public virtual ICollection<TicketFlight> TicketFlights { get; set; }
        public AirPort Departure { get; set; }
        public AirPort Arrival { get; set; }




    }
}
