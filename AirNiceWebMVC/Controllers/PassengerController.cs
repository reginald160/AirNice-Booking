using AirNice.Models.DTO;
using AirNice.Models.ViewModels.Passenger;
using AirNice.Utility.CoreHelpers;
using AirNiceWebMVC.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class PassengerController : Controller
    { private static string Url = StaticDetails.PassengerUrl;
        private readonly IPassengerServices _passengerServices;

        public PassengerController(IPassengerServices passengerServices)
        {
            _passengerServices = passengerServices;
        }

        public async Task<IActionResult> Index()
        {
            //return Json(new { data = await _unitOfWork.passenger.ReserveCollection(StaticDetails.PassengerUrl) });
            var response = await _passengerServices.GetPassengerss();
            return View(response);

        }
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _passengerServices.GetPassengerss() });
        
        }
           
        
        public async Task<IActionResult> Trash()
        {
           
            var response = await _passengerServices.GetPassengerss();
            return View(response);

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Register(PassengerDTO passenger)
        {
            await _passengerServices.AddPassenger(passenger);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(Guid id,PassengerDTO passenger)
        {
            await _passengerServices.UpdatePassenger(id, passenger);
            return RedirectToAction("GetAll");
        }



    }
}
