using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
   public  class Location : BaseModel
    {
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string? ZipCode { get; set; }
        public DateTimeKind? TimeZone { get; set; }

    }
}
