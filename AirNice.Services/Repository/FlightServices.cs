using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Utility.CoreHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
{
    public class FlightServices : GenericServices<Flight>, IFlightServices
    {
        public FlightServices(ApplicationDbContext context) : base(context)
        {
           
        }

        public List<Flight> Search(string stringValue, DateTime departureDate, DateTime arrivalDate)
        {
            var flights = _Context.Flights.Where(x => x.Deleted.Equals(!Universe.Deleted) && x.IsAvailable.Equals(Universe.Truth) &&
            (x.TypeOfPlane.Contains(stringValue) || x.TypeOfPlane.Contains(stringValue) || x.FlightNumber.Contains(stringValue) ||
            x.TypeOfPlane.Contains(stringValue) || x.ArrivateDateTime.Equals(arrivalDate) || x.DepartureDateTime.Equals(x.DepartureDateTime))).ToList();

            return flights;
        }
    }
}
