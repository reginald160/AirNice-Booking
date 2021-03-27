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
        bool IsUniqueUser(string username);
        AdditionalUser Authenticated(string username, string password);
        Task<ApplicationUser> Register(ApplicationUser user);
        Task<ApplicationUser> Creatidentityuser(string email, string password);
         Task<bool> Register(AdditionalUser user);
        Task DeleteUser(string email);
        Task<bool> Login(LoginDTO loginDTO);
    }
}
