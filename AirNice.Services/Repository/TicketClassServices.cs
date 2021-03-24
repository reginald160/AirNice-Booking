using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
{
    public class TicketClassServices : GenericServices<TicketClass>, ITicketClassServices
    {
        public TicketClassServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
