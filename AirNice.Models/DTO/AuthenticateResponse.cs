using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AirNice.Models.DTO
{
    public class AuthenticateResponse
    {
        public ApplicationUser AppUser { get; set; }
        public JwtSecurityToken TokenDescriptor { get; set; }

        public AuthenticateResponse(ApplicationUser user, JwtSecurityToken discriptor)
        {
            AppUser = user;
            TokenDescriptor = discriptor;

        }
    }
}
