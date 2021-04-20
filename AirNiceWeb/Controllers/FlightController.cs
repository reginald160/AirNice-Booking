using AirNice.Models.DTO;
using AirNiceWeb.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class FlightController : Controller
    {
        private readonly IFlightServices _flightServices;

        public FlightController(IFlightServices flightServices)
        {
            _flightServices = flightServices;
        }
        public async Task<IActionResult> Index()
        {
            //return Json(new { data = await _unitOfWork.passenger.ReserveCollection(StaticDetails.PassengerUrl) });
            var response = await _flightServices.GetFlightsFromTrash();
            return View(response);

        }
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _flightServices.GetFlights() });

        }


        public async Task<IActionResult> Trash()
        {
            var response = await _flightServices.GetFlights();
            return View(response);
        }

        [HttpGet]
        public async Task< IActionResult> AvailableFlight()
        {
            var response = await _flightServices.GetFlightsFromTrash();
            return View(response);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FlightDTO flight)
        {
            if (ModelState.IsValid)
            {
                await _flightServices.AddFlight(flight);
                return RedirectToAction("Index");
            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != null)
            {
                await _flightServices.Delete(id);
                return RedirectToAction("Index");
            }

            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Update(Guid id, FlightDTO flight)
        {
            await _flightServices.UpdateFlight(id,flight);
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public async Task<IActionResult> Filter(string stringValue, DateTime departureDate, DateTime arrivalDate)
        {
            var availableFlights =  await _flightServices.FilterFlight(stringValue, departureDate,arrivalDate);

            return View("FilterResult", availableFlights);
        }

        [HttpGet]
        public  IActionResult FilterResult (List<FlightDTO> availableFlights)
        {
            
            return View(availableFlights);
        }


    }
}
