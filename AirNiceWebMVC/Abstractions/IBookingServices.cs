using AirNice.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Abstractions
{
    public interface IBookingServices
    {
        [Get("/Booking/Index")]
        Task<List<BookingDTO>> GetBookingDetails();

        [Post("/Booking/Create")]
        Task<BookingDTO>  AddBooking(BookingDTO bookingDTO);
    }
}
