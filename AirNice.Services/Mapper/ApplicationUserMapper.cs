using AirNice.Models.DTO;
using AirNice.Models.Models;
using AutoMapper;


namespace AirNice.Services.Mapper
{
    public class ApplicationUserMapper : Profile
    {
        public ApplicationUserMapper()
        {
            CreateMap<ApplicationUser, ApplicationUserDTO>().ReverseMap();

        }
    }
}
