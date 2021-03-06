using AirNice.Data;
using AirNice.Models.DTO;
using AirNice.Models.Models;
using AirNice.Services.UnitOfWork;
using AirNice.Utility.CoreHelpers;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    //[ApiExplorerSettings(GroupName = "AirNiceAPIPassenger")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class PassengerController : BaseController
    {
        private readonly IHostingEnvironment env;
        public PassengerController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper, IHostingEnvironment env) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
            this.env = env;
        }
        /// <summary>
        /// This is the method that returns the list of active passengers
        /// </summary>
        /// <returns></returns>
        [HttpGet("AllPassengers")]
        [ProducesResponseType(400)]
        [EnableQuery()]
        public IActionResult Index()
        {
            var entities = _unitOfWork.passenger.ReserveCollection();
            var passengers = _mapper.Map<List<PassengerDTO>>(entities);

            return Ok(passengers);
        }

        [HttpGet("ArchivedPassingers")]
        [ProducesResponseType(400)]
        public IActionResult Trash()
        {
            var entities = _unitOfWork.passenger.Trashcollection();
            var passengers = _mapper.Map<List<PassengerDTO>>(entities);

            return Ok(passengers);
        }

        //[HttpGet("[action]")]
        //[ProducesResponseType(400)]
        //public IActionResult Location()
        //{
        //    var file = $@"{env.ContentRootPath}\Properties\location.json";
        //    //deserialize JSON from file  
        //    string Json = System.IO.File.ReadAllText(file);


        //    return Ok(Json);
        //}



        [HttpGet("GetPassenger/{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetPassenger(Guid id)
        {
            var entity = _unitOfWork.passenger.GetById(id);
            if (entity == null)
                return NotFound();

            var passenger = _mapper.Map<PassengerDTO>(entity);

            return Ok(passenger);
        }

        [HttpPost("NewPassenger/{passenger}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create( PassengerDTO passengerDTO)
        {
            if (ModelState.IsValid)
            {
                var passenger = _mapper.Map<Passenger>(passengerDTO);
                //var userId = await _unitOfWork.user.Creatidentityuser(passenger.Email, passenger.Password);
                var reponse = await _unitOfWork.passenger.AddAsync(passenger);

                return Ok(passenger);


            }
            return BadRequest(ModelState);
        }

        [HttpPatch("UpdatePassenger/{id,passenger}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        [Authorize]
        public async Task<IActionResult> Update(Guid id, PassengerDTO passengerDTO)
        {
            if (passengerDTO == null || id != passengerDTO.Id)
                return BadRequest(ModelState);
            if (ModelState.IsValid)
            {


                var passenger = _mapper.Map<Passenger>(passengerDTO);
                var sucess = await _unitOfWork.passenger.UpdateAsync(passenger);
                if (!sucess)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }
                return Ok();
            }
            return BadRequest(ModelState);

        }


        [HttpPatch("DeleteAndRetrieve/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAndRetrieve(Guid id)
        {
            if (!_unitOfWork.passenger.IsExisting(id))
                return BadRequest(ModelState);

            var sucess = await _unitOfWork.passenger.DeleteAndRetrieveAsync(id);
            if (!sucess)
            {
                ModelState.AddModelError("", Universe.Error500);
                return StatusCode(500, ModelState);
            }
            return Ok();


        }
    }
}
