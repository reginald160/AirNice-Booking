using AirNice.Data;
using AirNice.Services.WebServices.IRepository;
using AirNice.Services.WebServices.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.WebServices.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IHttpClientFactory _clientFActory;


        public UnitOfWork(IHttpClientFactory clientFActory)
        {
            _clientFActory = clientFActory;
            passenger = new PessengerServices(_clientFActory);
            bookingEnquiry = new BookingEnquiryServices(_clientFActory);

        }

        public IPassengerServices passenger { get; private set; }
        public IBookingEnquiryServices bookingEnquiry { get; private set; }

     

        public Task Save()
        {
            throw new NotImplementedException();
        }
    }
}

