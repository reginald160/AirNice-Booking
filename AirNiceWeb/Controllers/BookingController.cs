using AirNiceWeb.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingServices _bookingServices;
        public BookingController(IBookingServices bookingServices)
        {
            _bookingServices = bookingServices;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _bookingServices.GetBookings();
            return View();
        }

      
    }
}
