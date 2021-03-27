using AirNice.Data;
using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNice.Services.UnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController
    {
        public UsersController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
    
        public IActionResult Authenticate([FromBody] AdditionalUserDTO userDTO)
        {
            var authenticateUser = _mapper.Map<AdditionalUser>(userDTO);
            var user = _unitOfWork.user.Authenticated(authenticateUser.Username, authenticateUser.Password);
            if (user == null)
                return BadRequest(new { message = "username or password is in correct" });
            return Ok(user);
        }
        [AllowAnonymous]
        [HttpPost("[action]")]
    
        public async Task< IActionResult> AddUser([FromBody] AdditionalUserDTO userDTO)
        {
      
            var userMaped = _mapper.Map<ApplicationUser>(userDTO);
            var user = await _unitOfWork.user.Register(userMaped);
            if (user == null)
                return BadRequest(new { message = "username or password is in correct" });
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]

        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, false, true);
            if (result.Succeeded)
                return BadRequest(new { message = "username or password is in correct" });
            return Ok(loginDTO);
        }

        [AllowAnonymous]
        [HttpPost("[action]")]

        public async Task<IActionResult> LogOut()
        {
            var user = new LoginDTO();
            await _signInManager.SignOutAsync();

            return Ok(user);
           
        }
    }
}
