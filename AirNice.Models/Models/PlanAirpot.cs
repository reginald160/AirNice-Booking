using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
    public  class PlaneAirport : BaseModel2
    {
        
        public int PlaneID { get; set; }
        public int AirportID { get; set; }
        public string DepartureOrArrival { get; set; }

        public virtual AirPort Airport { get; set; }
        public virtual Plane Plane { get; set; }
    }
}
