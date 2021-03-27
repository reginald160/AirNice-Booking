using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
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
        Task<ApplicationUserDTO> AddUser(ApplicationUserDTO permissionDTO);
        [Post("/Users/Authenticate")]
        Task<ApplicationUserDTO> Authenticate(ApplicationUserDTO permissionDTO);

        [Post("/Users/Login")]
        Task<LoginDTO> Login(LoginDTO loginDTO);


    }
}
