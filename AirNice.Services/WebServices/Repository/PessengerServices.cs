using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.WebServices.Repository
{
   public class PessengerServices : GenericServices<Passenger>, IPassengerServices
    {
        public PessengerServices(ApplicationDbContext context) : base(context)
        {
        }

        public  bool Update(Passenger passenger)
        {
            _Context.Passengers.Update(passenger);
            var status = _Context.SaveChanges() > 0;
            return status ? true : false;
        }
    }
}
