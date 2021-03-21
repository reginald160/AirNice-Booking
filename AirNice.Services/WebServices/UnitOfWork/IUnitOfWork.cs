using AirNice.Data;
using AirNice.Services.WebServices.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.WebServices.UnitOfWork
{
    
        public interface IUnitOfWork 
        {
            IPassengerServices passenger { get; }
           IBookingEnquiryServices bookingEnquiry { get; }

            Task Save();

        }



    


       
}
