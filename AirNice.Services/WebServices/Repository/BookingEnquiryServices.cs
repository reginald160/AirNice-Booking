using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Models.ViewModels.BookingEnquiry;
using AirNice.Services.WebServices.IRepository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AirNice.Services.WebServices.Repository
{
    public class BookingEnquiryServices :  GenericServices<BookingEnquiryViewModel>, IBookingEnquiryServices
    {
        public BookingEnquiryServices(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

    }
}
