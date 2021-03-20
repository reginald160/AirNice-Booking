using AirNice.Data;
using AirNice.Services.IRepository;
using AirNice.Services.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            passenger = new PessengerServices(_context);
            bookingEnquiry = new BookingEnquiryServices(_context);

        }

        public IPassengerServices passenger { get; private set; }
        public IBookingEnquiryServices bookingEnquiry { get; private set; }


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

