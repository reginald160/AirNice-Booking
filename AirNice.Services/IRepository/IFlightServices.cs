using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Services.IRepository
{
    public interface IFlightServices : IGenericServices<Flight>
    {
        List<Flight> Search(string stringValue, DateTime departureDate, DateTime arrivalDate);
    }
}
