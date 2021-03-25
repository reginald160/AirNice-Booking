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
    public class PermissionController : BaseController
    {
        public PermissionController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context, SignInManager<ApplicationUser> signInManager, IMapper mapper) : base(unitOfWork, userManager, roleManager, context, signInManager, mapper)
        {
        }

        /// <summary>
        /// This is the method that returns the list of active Enquiries
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<PermissionDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Index()
        {
            var entities = _unitOfWork.permission.ReserveCollection();
            var bookings = _mapper.Map<List<PermissionDTO>>(entities);

            return Ok(bookings);
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(List<PermissionDTO>))]
        [ProducesResponseType(400)]
        public IActionResult Trash()
        {
            var entities = _unitOfWork.permission.Trashcollection();
            var bookings = _mapper.Map<List<PermissionDTO>>(entities);

            return Ok(bookings);
        }



        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(PermissionDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesDefaultResponseType]
        public IActionResult GetPermission(Guid id)
        {
            var entity = _unitOfWork.permission.GetById(id);
            if (entity == null)
                return NotFound();

            var booking = _mapper.Map<PermissionDTO>(entity);

            return Ok(booking);
        }

        [HttpPost("[action]")]
        [ProducesResponseType(201, Type = typeof(PermissionDTO))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] PermissionDTO bookingDTO)
        {
            if (ModelState.IsValid)
            {
                var booking = _mapper.Map<Permission>(bookingDTO);
                var success = await _unitOfWork.permission.AddAsync(booking);
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
        public async Task<IActionResult> Update(Guid id, [FromBody] PermissionDTO permissionDTO)
        {
            if (permissionDTO == null || id != permissionDTO.Id)
                return BadRequest(ModelState);
            if (ModelState.IsValid)
            {


                var permission = _mapper.Map<Permission>(permissionDTO);
                var sucess = await _unitOfWork.permission.UpdateAsync(permission);
                if (!sucess)
                {
                    ModelState.AddModelError("", Universe.Error500);
                    return StatusCode(500, ModelState);
                }
                return Ok(permission);
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

            var sucess = await _unitOfWork.permission.DeleteAndRetrieveAsync(id);
            if (!sucess)
            {
                ModelState.AddModelError("", Universe.Error500);
                return StatusCode(500, ModelState);
            }
            return Ok();


        }


    }
}
