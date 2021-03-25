using AirNice.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Abstractions
{
    public interface IBookingEnquiryServices
    {

        [Get("/BookingEnquiry/Index")]
        Task<List<BookingEnquiryDTO>> GetBookingEnquiries();
        [Get("/BookingEnquiry/Trash")]
        Task<List<BookingEnquiryDTO>> GetBookingEnquiryFromTrash();

        [Post("/BookingEnquiry/GetBookingEnquiry")]
        Task<BookingEnquiryDTO> GetBookingEnquiry(Guid id);

        [Post("/BookingEnquiry/Create")]
        Task<BookingEnquiryDTO> AddBookingEnquiry(BookingEnquiryDTO bookingEnquiryDTO);
        [Post("/BookingEnquiry/Update")]
        Task<BookingEnquiryDTO> UpdateBookingEnquiry(Guid id, BookingEnquiryDTO bookingEnquiryDTO);
        [Post("/BookingEnquiry/DeleteAndRetrieve")]
        Task Delete(Guid id);
    }
}
