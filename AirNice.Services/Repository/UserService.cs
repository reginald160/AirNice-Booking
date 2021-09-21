using AirNice.Data;
using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Utility;
using AirNice.Utility.CoreHelpers;
using AirNice.Utility.Response;
using AutoMapper.Configuration;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AirNice.Services.Repository
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSetings _appSettings;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;
        //private readonly ILogger<ApplicationUser> _logger;


        public UserService(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }
        private List<AdditionalUser> _users = new List<AdditionalUser>
        {
            new AdditionalUser { Id = Guid.NewGuid(), FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };
        public UserService(ApplicationDbContext context, IOptions<AppSetings> appSettings, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _appSettings = appSettings.Value;
            _configuration = configuration;
            this.roleManager = roleManager;
        }

        

        public async Task<string> Creatidentityuser(ApplicationUser user)
        {
            var result = await _userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var idUser = await _userManager.FindByEmailAsync(user.Email);
                return idUser != null ? code : null;
            }
            return null;
        }

      

        public async Task<AuthenticateResponse> Authenticated(AuthenticateRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));

                var tokenDescriptor = new JwtSecurityToken(
                    issuer: _appSettings.ValidIssuer,
                    audience: _appSettings.ValidAudience,
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                

                return new AuthenticateResponse(user, tokenDescriptor);
            }
            return null;
        }
            public bool IsUniqueUser(string username)
            {
                var user = _context.AdditionalUsers.Where(x => x.Username.Equals(username)).FirstOrDefault();
                return user == null ? true : false;
            }

            public async Task<ResponseMessage> RegisterUser(RegisterDTO request)
            {
                var userExists = await _userManager.FindByNameAsync(request.Email);
                if (userExists != null)
                return new ResponseMessage { Status = "Error", Message = "User already exists!" };

                 ApplicationUser user = new ApplicationUser()
                 {
                    Email = request.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.Email
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                return new ResponseMessage { Status = "Error", Message = "User creation failed! Please check user details and try again." };

                if (result.Succeeded)
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));

                    var idUser = await _userManager.FindByEmailAsync(user.Email);

                return new ResponseMessage { Status = "Success", Message = "User created successfully!", Data = code };
            }

                return null;
            }

            public async Task<ResponseMessage> RegisterAdmin(RegisterDTO request)
            {

                var userExists = await _userManager.FindByNameAsync(request.Email);
                if (userExists != null)
                     return new ResponseMessage { Status = "Error", Message = "User already exists!" };

                ApplicationUser user = new ApplicationUser()
                  {
                     Email = request.Email,
                     SecurityStamp = Guid.NewGuid().ToString(),
                     UserName = request.Email
                 };
                 var result = await _userManager.CreateAsync(user, request.Password);
                  if (!result.Succeeded)
                      return  new ResponseMessage { Status = "Error", Message = "User creation failed! Please check user details and try again." };

                if (!await roleManager.RoleExistsAsync(Universe.Admin))
                await roleManager.CreateAsync(new IdentityRole(Universe.Admin));
                if (!await roleManager.RoleExistsAsync(Universe.User))
                await roleManager.CreateAsync(new IdentityRole(Universe.User));

                if (await roleManager.RoleExistsAsync(Universe.Admin))
                await _userManager.AddToRoleAsync(user, Universe.Admin);

                 return new ResponseMessage { Status = "Success", Message = "User created successfully!" };


            }

            public async Task VerifyEmail(string email)
            {
                var user = await _userManager.FindByNameAsync(email);
                await _userManager.DeleteAsync(user);
            }

            public async Task DeleteUser(string email)
            {
                var user = await _userManager.FindByNameAsync(email);
                await _userManager.DeleteAsync(user);
            }

           
            public async Task<CoreProfile> CreateProfile(CoreProfile profileData)
            {
                await _context.UserProfiles.AddAsync(profileData);
                var profile = await _context.SaveChangesAsync() > 0;
                if (profile)
                {
                    var user = await _userManager.FindByNameAsync(profileData.Email);
                    user.IsProfiled = true;
                    await _context.SaveChangesAsync();
                    return profileData;
                }
                return null;

            }


            private string generateJwtToken(ApplicationUser user)
            {
                // generate token that is valid for 7 days
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    { new Claim(ClaimTypes.Name, user.Id.ToString()) ,
                // new Claim(ClaimTypes.Role, user.Role.Title)
                }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);

            }

    }
    
}
