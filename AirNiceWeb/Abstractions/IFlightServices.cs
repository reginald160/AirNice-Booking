using AirNice.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWeb.Abstractions
{
    public interface IFlightServices
    {
        [Get("/Flight/Index")]
        Task<List<FlightDTO>> GetFlights();
        [Get("/Flight/Trash")]
        Task<List<FlightDTO>> GetFlightsFromTrash();
        [Get("/Flight/FilterFlight")]
        Task<List<FlightDTO>> FilterFlight(string value, DateTime departureTime, DateTime arrivalTime);

        [Post("/Flight/GetFlight")]
        Task<FlightDTO> GetFlight(Guid id);

        [Post("/Flight/AvailableFlight")]
        Task<FlightDTO> AvailableFlight();

        [Post("/Flight/Create")]
        Task<FlightDTO> AddFlight(FlightDTO flightDTO);
        [Post("/Flight/Update")]
        Task<FlightDTO> UpdateFlight(Guid id, FlightDTO flightDTO);
        [Post("/Flight/DeleteAndRetrieve")]
        Task Delete(Guid id);
    }
}
