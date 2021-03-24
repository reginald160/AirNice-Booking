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
			CreateMap<Passenger, PassengerDTO>().ReverseMap();
			CreateMap<BookingEnquiry, BookingEnquiryDTO>().ReverseMap();
			CreateMap<AdditionalUser, AdditionalUserDTO>().ReverseMap();
			CreateMap<Booking, BookingDTO>().ReverseMap();

		}

	}
}
