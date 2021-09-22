using AirNice.Data;
using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using AirNice.Services.UnitOfWork;
using AirNice.Utility.Response;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AirNice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;

        public UsersController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, ApplicationDbContext context,
            SignInManager<ApplicationUser> signInManager, IMapper mapper, IUserService userService)
            : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        //[Route("Authenticate")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authenticate (AuthenticateRequest request)
        {
            if (ModelState.IsValid)
            {
                var response =  await _userService.Authenticated(request);
                if(response != null)
                {
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(response.TokenDescriptor),
                        expiration = response.TokenDescriptor.ValidTo
                    });

                }
            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterDTO request)
        {
            if(ModelState.IsValid)
            {
                var response = _userService.RegisterUser(request);
                return Ok(response);
            }

            return BadRequest(new { Message ="Invalid Parameters"});
        }

        [HttpPost]
        [Route("RegisterAdmin")]
        public async Task<IActionResult> RegisterAdmin(RegisterDTO request)
        {
            if(ModelState.IsValid)
            {
                var response = _userService.RegisterAdmin(request);
                return Ok(response);
            }
            return BadRequest();
        }
    }
}
