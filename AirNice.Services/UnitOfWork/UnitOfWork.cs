using AirNice.Data;
using AirNice.Services.IRepository;
using AirNice.Services.Repository;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<IdentityUser> userManager;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            passenger = new PessengerServices(_context);
            bookingEnquiry = new BookingEnquiryServices(_context);
            user = new UserService(_context, userManager);
            permission = new PermissionServices(_context);
            ticketClass = new TicketClassServices(_context);
            booking = new BookingServices(_context);

        }

        public UnitOfWork(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        public IPassengerServices passenger { get; private set; }
        public IBookingEnquiryServices bookingEnquiry { get; private set; }
        public IUserServices user { get; private set; }
        public IPermissionServices permission { get; private set; }
        public IBookingServices booking { get; private set; }
        public ITicketClassServices ticketClass { get; private set; }


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

