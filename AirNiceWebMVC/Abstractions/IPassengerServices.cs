﻿using AirNice.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Abstractions
{
    public interface IPassengerServices 
    {
        [Get("/Passenger/Index")]
        Task<List<PassengerDTO>> GetPassengerss();
        [Get("/Passenger/Trash")]
        Task<List<PassengerDTO>> GetPassengersFromTrash();

        [Post("/Passenger/GetPassenger")]
        Task<PassengerDTO> GetPassenger(Guid id);

        [Post("/Passenger/Create")]
        Task<PassengerDTO> AddPassenger(PassengerDTO passengerDTO);
        [Post("/Passenger/Update")]
        Task<PassengerDTO> UpdatePassenger(Guid id, PassengerDTO passengerDTO);
        [Post("/Passenger/DeleteAndRetrieve")]
        Task Delete(Guid id);
    }
}
