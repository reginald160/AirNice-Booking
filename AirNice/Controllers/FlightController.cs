using AirNice.Data;
using AirNice.Models.DTO;
using AirNice.Models.Models;
using AirNice.Services.UnitOfWork;
using AirNice.Utility.CoreHelpers;
using AutoMapper;
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
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class FlightController : BaseController
    {
        public FlightController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
        }

        /// <summary>
        /// This is the method that returns the list of active flight
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<FlightDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Index()
        {
            var entities = _unitOfWork.flight.ReserveCollection();
            var flights = _mapper.Map<List<FlightDTO>>(entities);

            return Ok(flights);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<FlightDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Trash()
        {
            var entities = _unitOfWork.flight.Trashcollection();
            var flights = _mapper.Map<List<FlightDTO>>(entities);

            return Ok(flights);
        }

        //[HttpGet("[action]")]
        //[ProducesResponseType(200, Type = typeof(List<FlightDTO>))]
        //[ProducesResponseType(400)]
        //public IActionResult AvailableFlight()
        //{
        //    var entities = _unitOfWork.flight.ReserveCollection().Where(x => x.IsAvailable.Equals(true));
        //    var flights = _mapper.Map<List<FlightDTO>>(entities);

        //    return Ok(flights);
        //}



        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(FlightDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetFlight(Guid id)
        {
            var entity = _unitOfWork.flight.GetById(id);
            if (entity == null)
                return NotFound();

            var flight = _mapper.Map<FlightDTO>(entity);

            return Ok(flight);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201, Type = typeof(FlightDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] FlightDTO FlightDTO)
        {
            if (ModelState.IsValid)
            {
                var flight = _mapper.Map<Flight>(FlightDTO);
                    var reponse = await _unitOfWork.flight.AddAsync(flight);

                    return Ok(reponse);
            }
            return BadRequest(ModelState);
        }

        [HttpPatch("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        //[Authorize]
        public async Task<IActionResult> Update(Guid id, [FromBody] FlightDTO FlightDTO)
        {
            if (FlightDTO == null || id != FlightDTO.Id)
                return BadRequest(ModelState);
            if (ModelState.IsValid)
            {


                var flight = _mapper.Map<Flight>(FlightDTO);
                var sucess = await _unitOfWork.flight.UpdateAsync(flight);
                if (!sucess)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }
                return Ok();
            }
            return BadRequest(ModelState);

        }

        [HttpPatch("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAndRetrieve(Guid id)
        {
            if (!_unitOfWork.flight.IsExisting(id))
                return BadRequest(ModelState);

            var sucess = await _unitOfWork.flight.DeleteAndRetrieveAsync(id);
            if (!sucess)
            {
                ModelState.AddModelError("", Universe.Error500);
                return StatusCode(500, ModelState);
            }
            return Ok();


        }


        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<PermissionDTO>))]
        [ProducesResponseType(400)]
        public IActionResult FilterFlight(string value, DateTime departureTime, DateTime arrivalTime )
        {
            var entities = _unitOfWork.flight.Search(value, departureTime,arrivalTime);
            var Flights = _mapper.Map<List<FlightDTO>>(entities);

            return Ok(Flights);
        }
    }
}
