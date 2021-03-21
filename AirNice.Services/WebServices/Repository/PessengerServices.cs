using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Models.ViewModels.Passenger;
using AirNice.Services.WebServices.IRepository;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace AirNice.Services.WebServices.Repository
{
   public class PessengerServices : GenericServices<PassengerViewModel>, IPassengerServices
    {
        public PessengerServices(IHttpClientFactory clientFactory) : base(clientFactory)
        {
        }

  
    }
}
