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
    public class BookingController : BaseController
    {
        public BookingController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
        }

        /// <summary>
        /// This is the method that returns the list of active Enquiries
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<BookingDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Index()
        {
            var entities = _unitOfWork.booking.ReserveCollection();
            var bookings = _mapper.Map<List<BookingDTO>>(entities);

            return Ok(bookings);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<BookingDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Trash()
        {
            var entities = _unitOfWork.booking.Trashcollection();
            var bookings = _mapper.Map<List<BookingDTO>>(entities);

            return Ok(bookings);
        }



        [HttpGet("[action]/id")]
        [ProducesResponseType(200, Type = typeof(BookingDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetBooking(Guid id)
        {
            var entity = _unitOfWork.booking.GetById(id);
            if (entity == null)
                return NotFound();

            var booking = _mapper.Map<BookingDTO>(entity);

            return Ok(booking);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201, Type = typeof(BookingDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] BookingDTO bookingDTO)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<Booking>(bookingDTO);
                var success = await _unitOfWork.booking.AddAsync(booking);
                if (!success)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }

                return Ok(booking);

            }
            return BadRequest(ModelState);
        }

        [HttpPatch("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookingDTO bookingDTO)
        {
            if (bookingDTO == null || id != bookingDTO.Id)
                return BadRequest(ModelState);
            if (ModelState.IsValid)
            {


                var booking = _mapper.Map<Booking>(bookingDTO);
                var sucess = await _unitOfWork.booking.UpdateAsync(booking);
                if (!sucess)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }
                return Ok(booking);
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
            if (!_unitOfWork.booking.IsExisting(id))
                return BadRequest(ModelState);

            var sucess = await _unitOfWork.booking.DeleteAndRetrieveAsync(id);
            if (!sucess)
            {
                ModelState.AddModelError("", Universe.Error500);
                return StatusCode(500, ModelState);
            }
            return Ok();


        }

    }
}
