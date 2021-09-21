using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Models.Enum;

namespace AirNice.Models.ViewModels.BookingEnquiry
{
	public class BookingAvailabiltyViewModel
	{
		public string Destination { get; set; }
		public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }
		public int Seat { get; set; }
		public Adult NumbAdults { get; set; }
		public Children NumbChildern { get; set; }


	}
}
