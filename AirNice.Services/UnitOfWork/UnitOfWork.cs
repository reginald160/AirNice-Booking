using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Services.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            passenger = new PessengerServices(_context);
            bookingEnquiry = new BookingEnquiryServices(_context);
            user = new UserService(_context, userManager);
            permission = new PermissionServices(_context);
            ticketClass = new TicketClassServices(_context);
            booking = new BookingServices(_context);
            flight = new FlightServices(_context);
            ticketFlight = new TicketFlightServices(_context);
            ticket = new TicketServices(_context);

        }

       

        public IPassengerServices passenger { get; private set; }
        public IBookingEnquiryServices bookingEnquiry { get; private set; }
        public IUserService user { get; private set; }
        public IPermissionServices permission { get; private set; }
        public IBookingServices booking { get; private set; }
        public IFlightServices flight { get; private set; }
        public ITicketClassServices ticketClass { get; private set; }
		public ITicketFlightServices ticketFlight { get; private set; }

		public ITicketServices ticket { get; private set; }

     

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }



    }
}

