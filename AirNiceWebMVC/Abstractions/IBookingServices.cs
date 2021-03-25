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
        Task<List<BookingDTO>> GetBookings();
        [Get("/Booking/Trash")]
        Task<List<BookingDTO>> GetBookingsFromTrash();

        [Post("/Booking/GetBooking")]
        Task<BookingDTO> GetBooking(Guid id);

        [Post("/Booking/Create")]
        Task<BookingDTO>  AddBooking(BookingDTO bookingDTO);
        [Post("/Booking/Update")]
        Task<BookingDTO> UpdateBooking(Guid id,BookingDTO bookingDTO);
        [Post("/Booking/DeleteAndRetrieve")]
        Task Delete(Guid id);
    }
}
