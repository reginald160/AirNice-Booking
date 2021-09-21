using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
{
	public class TicketFlightServices : GenericServices<TicketFlight>, ITicketFlightServices
	{
		public TicketFlightServices(ApplicationDbContext context) : base(context)
		{
           
        }

        public IEnumerable<TicketFlight> FindByFlight(int flightId)
        {
            var result = this._Context.TicketFlight.Where(ticketFlight => ticketFlight.FlightID == flightId);

            return result;
        }

        public IEnumerable<TicketFlight> FindByTicket(Guid ticketId)
        {
            var result = this._Context.TicketFlight.Where(ticketFlight => ticketFlight.TicketId == ticketId);

            return result;
        }
    }
}
