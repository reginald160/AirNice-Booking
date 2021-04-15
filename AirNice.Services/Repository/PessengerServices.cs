using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Utility.CoreHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
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
