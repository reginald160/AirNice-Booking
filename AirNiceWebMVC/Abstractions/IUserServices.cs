using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNiceWebMVC.ViewModel.User;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Abstractions
{
    [Headers("Content-Type: application/json")]
    public interface IUserServices
    {
        [Post("/Users/Register")]
        [Headers("User-Agent:UserService")]
        Task Register([Body] RegisterViewModel viewModel);
        [Post("/Users/Authenticate")]
        Task<ApplicationUserDTO> Authenticate(ApplicationUserDTO permissionDTO);

        [Post("/Users/RegisterAdmin")]
        Task<ApplicationUserDTO> RegisterAdmin(LoginDTO loginDTO);

        [Post("/Users/AllUsers/{id}")]
        Task<ApplicationUserDTO> AllUsers(Guid id, [Authorize("Bearer")] string token);
      

        [Post("/Users/UserProfile")]
        Task<CoreProfile> UserProfile(ProfileDTO profile);


    }
}
