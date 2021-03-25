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
    //[ApiExplorerSettings(GroupName = "AirNiceAPIBookingEnquiry")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public class BookingEnquiryController : BaseController
    {
        public BookingEnquiryController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
        }
        /// <summary>
        /// This is the method that returns the list of active Enquiries
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<BookingEnquiryDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Index()
        {
            var entities = _unitOfWork.bookingEnquiry.ReserveCollection();
            var bookingEnquirys = _mapper.Map<List<BookingEnquiryDTO>>(entities);

            return Ok(bookingEnquirys);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<BookingEnquiryDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Trash()
        {
            var entities = _unitOfWork.bookingEnquiry.Trashcollection();
            var bookingEnquirys = _mapper.Map<List<BookingEnquiryDTO>>(entities);

            return Ok(bookingEnquirys);
        }



        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(BookingEnquiryDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetBookingEnquiry(Guid id)
        {
            var entity = _unitOfWork.bookingEnquiry.GetById(id);
            if (entity == null)
                return NotFound();

            var bookingEnquiry = _mapper.Map<BookingEnquiryDTO>(entity);

            return Ok(bookingEnquiry);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201, Type = typeof(BookingEnquiryDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] BookingEnquiryDTO bookingEnquiryDTO)
        {
            if (ModelState.IsValid)
            {
                var bookingEnquiry = _mapper.Map<BookingEnquiry>(bookingEnquiryDTO);
                var success = await _unitOfWork.bookingEnquiry.AddAsync(bookingEnquiry);
                if (!success)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }

                return Ok(bookingEnquiry);

            }
            return BadRequest(ModelState);
        }

        [HttpPatch("[action]")]
        [ProducesResponseType(204)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update(Guid id, [FromBody] BookingEnquiryDTO bookingEnquiryDTO)
        {
            if (bookingEnquiryDTO == null || id != bookingEnquiryDTO.Id)
                return BadRequest(ModelState);
            if (ModelState.IsValid)
            {


                var bookingEnquiry = _mapper.Map<BookingEnquiry>(bookingEnquiryDTO);
                var sucess = await _unitOfWork.bookingEnquiry.UpdateAsync(bookingEnquiry);
                if (!sucess)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }
                return Ok(bookingEnquiry);
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
            if (!_unitOfWork.bookingEnquiry.IsExisting(id))
                return BadRequest(ModelState);

            var sucess = await _unitOfWork.bookingEnquiry.DeleteAndRetrieveAsync(id);
            if (!sucess)
            {
                ModelState.AddModelError("", Universe.Error500);
                return StatusCode(500, ModelState);
            }
            return Ok();


        }
    }
}
