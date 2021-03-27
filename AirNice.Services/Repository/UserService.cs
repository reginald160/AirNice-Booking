using AirNice.Data;
using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
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
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly ILogger<ApplicationUser> _logger;


        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
         
        }

        public UserService(ApplicationDbContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public async Task<string> Creatidentityuser (ApplicationUser user)
        {   
              var result =   await _userManager.CreateAsync(user, user.Passcode);
            if(result.Succeeded)
            {
                var idUser =  await _userManager.FindByEmailAsync(user.Email);
                return idUser != null ? idUser.Id : null;
            }
            return null;
        }

        public async Task<bool> Login(LoginDTO loginDTO)
        {
            //var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, true,  false);
            //if (result.Succeeded)
            //{
            //    _logger.LogInformation("User logged in.");
            //    return true;
            //}
            return false;
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
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.Title)
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

        public async Task<ApplicationUser> Register(ApplicationUser user)
        {

            var result = await _userManager.CreateAsync(user, user.Passcode);
            if (result.Succeeded)
            {
                user.IsSuccessful = true;
                return user;
            }
            return user;
        }

    

        public async Task DeleteUser(string email)
        {
                var user = await  _userManager.FindByNameAsync(email);
            await _userManager.DeleteAsync(user);
        }

        public Task<ApplicationUser> Creatidentityuser(string email, string password)
        {
            throw new NotImplementedException();
        }

     
    }
}
