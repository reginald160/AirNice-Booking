using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
{
    public class BookingServices : GenericServices<Booking>, IBookingServices
    {
        public BookingServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
