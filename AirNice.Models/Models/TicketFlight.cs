using System;

namespace AirNice.Models.Models
{
	public class TicketFlight : BaseModel
	{
       
     
        public string SeatCode { get; set; }
        public bool RoundTrip { get; set; }
        public int? Order { get; set; }
        public int FlightID { get; set; }
		public virtual Flight Flight { get; set; }
        public Guid? TicketId { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}