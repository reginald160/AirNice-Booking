using AirNice.Data;
using AirNice.Services.IRepository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.UnitOfWork
{
    
        public interface IUnitOfWork : IDisposable
        {
            IPassengerServices passenger { get; }
                
            Task Save();

        }



    


       
}
