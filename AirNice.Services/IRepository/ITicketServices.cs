using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Services.IRepository
{
	public interface ITicketServices : IGenericServices<Ticket>
	{
		IEnumerable<Ticket> FindByAccount(int accountId);
	}
}
