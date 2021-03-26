using AirNice.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Abstractions
{
   public interface IUserServices
    {
        [Post("/Users/AddUser")]
        Task<string> AddUser(ApplicationUserDTO permissionDTO);
    }
}
