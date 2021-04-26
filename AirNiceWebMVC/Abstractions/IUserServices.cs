using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
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
        Task<ApplicationUserDTO> Login(LoginDTO loginDTO);

        [Post("/Users/UserProfile")]
        Task<CoreProfile> UserProfile(ProfileDTO profile);


    }
}
