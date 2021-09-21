using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNice.Utility.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.IRepository
{
    public interface IUserService
    {
      
         Task<CoreProfile> CreateProfile(CoreProfile user);
        Task DeleteUser(string email);
        Task<ResponseMessage> RegisterUser(RegisterDTO request);
        Task<AuthenticateResponse> Authenticated(AuthenticateRequest request);
        Task<ResponseMessage> RegisterAdmin(RegisterDTO request);




    }
}
