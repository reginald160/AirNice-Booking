using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Services.IRepository
{
	public interface ITicketFlightServices : IGenericServices<TicketFlight>
	{
		IEnumerable<TicketFlight> FindByFlight(int flightId);
		IEnumerable<TicketFlight> FindByTicket(Guid ticketId);

	}
}
