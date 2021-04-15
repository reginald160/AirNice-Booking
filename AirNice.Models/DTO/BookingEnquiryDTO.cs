using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Models.Enum;

namespace AirNice.Models.DTO
{
    public class BookingEnquiryDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public BookingEnquiryType BookingEnquiryType { get; set; }
    }
}
