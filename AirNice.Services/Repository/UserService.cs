using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.Repository
{
    public class UserService : IUserServices
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSettings _appSettings;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public UserService(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public AdditionalUser Authenticated(string username, string password)
        {
            var user = _context.AdditionalUsers.SingleOrDefault(x => x.Username.Equals(username) && x.Password.Equals(password));
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This is used to sign in and verify user, the user must be Authenticated. 1123445@#$%&^*&^");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return user;
        }

        public bool IsUniqueUser(string username)
        {
            var user = _context.AdditionalUsers.Where(x => x.Username.Equals(username)).FirstOrDefault();
            return user == null ? true : false;
        }

        public async Task<bool> Register(AdditionalUser user)
        {
           await _context.AdditionalUsers.AddAsync(user);
            var sucess = await _context.SaveChangesAsync() > 0;
            return sucess ? true : false;
        }
    }
}
