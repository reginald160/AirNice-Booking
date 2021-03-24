using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
    public class BookingDTO : BaseDTO
    {
        public string Description { get; set; }
        public BookingType BookingType { get; set; }
        public Guid PassengerId { get; set; }
    }
}
