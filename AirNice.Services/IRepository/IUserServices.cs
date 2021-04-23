using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.IRepository
{
    public interface IUserServices
    {
       
        Task<CoreProfile> CreateProfile(CoreProfile user);
        Task DeleteUser(string email);
       
    }
}
