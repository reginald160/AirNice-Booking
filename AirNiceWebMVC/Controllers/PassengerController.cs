using AirNice.Models.ViewModels.Passenger;
using AirNice.Services.WebServices.UnitOfWork;
using AirNice.Utility.CoreHelpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class PassengerController : BaseController
    { private static string Url = StaticDetails.PassengerUrl;
        public PassengerController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<IActionResult> Index()
        {
            //return Json(new { data = await _unitOfWork.passenger.ReserveCollection(StaticDetails.PassengerUrl) });
            var response = await _unitOfWork.passenger.ReserveCollection(Url + "/Index");
            return View(response);

        }
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _unitOfWork.passenger.ReserveCollection(StaticDetails.PassengerUrl) });
            return View();
        }
        public async Task<IActionResult> Trash()
        {
           
            var response = await _unitOfWork.passenger.ReserveCollection(Url + "/Trash");
            return View(response);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Create(PassengerViewModel passenger)
        {
            await _unitOfWork.passenger.AddAsync(Url + "/Create", passenger);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(PassengerViewModel passenger)
        {
            await _unitOfWork.passenger.UpdateAsync(Url + "/Update", passenger);
            return RedirectToAction("GetAll");
        }



    }
}
