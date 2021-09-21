using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
{
	public class TicketServices : GenericServices<Ticket>, ITicketServices
	{
		public TicketServices(ApplicationDbContext context) : base(context)
		{
		}

		public IEnumerable<Ticket> FindByAccount(int accountId)
		{
			throw new NotImplementedException();
		}
		public override Task<bool> UpdateAsync(Ticket ticket)
		{
			var currentTicket = this._Context.Ticket.Find(ticket.Id);

			ticket.PassengerTickets = currentTicket.PassengerTickets;
			ticket.TicketFlights = currentTicket.TicketFlights;
			return base.UpdateAsync(ticket);
		}
		
	}
}
