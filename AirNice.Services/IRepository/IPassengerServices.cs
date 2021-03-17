using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.IRepository
{
   public  interface IPassengerServices : IGenericServices<Passenger>
    {
         bool Update(Passenger passenger);
    }
}
