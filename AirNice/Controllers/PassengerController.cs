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
    public class PassengerController : BaseController
    {
        public PassengerController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            var entities = _unitOfWork.passenger.ReserveCollection();
            var passengers = _mapper.Map<List<PassengerDTO>>(entities);

            return Ok(passengers);
        }

        [HttpGet("[action]")]
        public IActionResult Trash()
        {
            var entities = _unitOfWork.passenger.Trashcollection();
            var passengers = _mapper.Map<List<PassengerDTO>>(entities);

            return Ok(passengers);
        }



        [HttpGet("[action]")]
        public IActionResult GetPassenger(Guid id)
        {
            var entity = _unitOfWork.passenger.GetById(id);
            if (entity == null)
                return NotFound();

            var passenger = _mapper.Map<PassengerDTO>(entity);

            return Ok(passenger);
        }

        [HttpPost("[action]")]
        public async Task< IActionResult> Create([FromBody] PassengerDTO passengerDTO)
        {
            if(ModelState.IsValid)
            {
                var passenger = _mapper.Map<Passenger>(passengerDTO);
                var success = await _unitOfWork.passenger.AddAsync(passenger);
                if (!success)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }

                return Ok();

            }
            return BadRequest(ModelState);
        }
        [HttpPatch("[action]")]
        public async Task< IActionResult> Update(Guid id, [FromBody] PassengerDTO passengerDTO)
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

        [HttpPatch("[action]")]
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
