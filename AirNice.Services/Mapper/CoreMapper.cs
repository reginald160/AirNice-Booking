using AirNice.Models.DTO;
using AirNice.Models.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Services.Mapper
{


   public  class CoreMapper : Profile
	{
		public CoreMapper()
		{
			CreateMap<Booking, BookingDTO>().ReverseMap();
			CreateMap<Flight, FlightDTO>().ReverseMap();
			CreateMap<Passenger, PassengerDTO>().ReverseMap();
			CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();

		}

	}
}
