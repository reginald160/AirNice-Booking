using AirNice.Models.DTO;
using AirNice.Models.ViewModels.BookingEnquiry;
using AirNiceWebMVC.Abstractions;
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

        //[HttpGet]
        //public ActionResult Find()
        //{
        //    var airports = this._flightServices.GetFlights(); 
        //    var
        //    var regions = this.CountryService.FindAll().Select(country => country.Region).Distinct();
        //    var passengers = this.PassengerTypeService.FindAll();
        //    var airportRegion = new List<AirportRegionModel>
        //    {
        //        new AirportRegionModel
        //        {
        //            Region = Constant.CONST_DB_NAME_VIETNAM,
        //            Airports = airports.Where(airport => airport.Country.Name.Equals(Constant.CONST_DB_NAME_VIETNAM))
        //                .OrderBy(airport => airport.Name)
        //        }
        //    };

        //    foreach (var region in regions)
        //    {
        //        var airportList = airports.Where(airport => airport.Country.Region.Equals(region)
        //        && !airport.Country.Name.Equals(Constant.CONST_DB_NAME_VIETNAM));

        //        if (airportList.Count() != 0)
        //            airportRegion.Add(new AirportRegionModel
        //            {
        //                Region = region,
        //                Airports = airportList
        //            });
        //    }

        //    ViewData["airports"] = airportRegion;
        //    ViewData["passengers"] = passengers;
        //    ViewData["seatClassList"] = this.SeatClassService.FindAll();
        //    SessionUtility.RemoveBookingSession();

        //    return View();
        //}






        [HttpGet]
        public IActionResult AvailableFlight()
        {
           //// var flights = new List<FlightDTO>
           // {
           //     new FlightDTO()
           //     {
           //         Id = new Guid("060F7763-72B5-491E-B6C1-15D9A72E200E"),
           //         FlightNumber = "XRFCGT12",
           //         ArrivateDateTime = DateTime.Now

           //     },
           //      new FlightDTO()
           //     {
           //         Id = new Guid("65339990-C716-43F3-9846-2FA2D3C4DEDE"),
           //         FlightNumber = "MHYGH233",
           //         ArrivateDateTime = DateTime.Now

           //     },
           //        new FlightDTO()
           //     {
           //         Id = new Guid("76A6A195-4A5B-45BA-B855-E05E5BD9DBD5"),
           //         FlightNumber = "Maxi2132",
           //         ArrivateDateTime = DateTime.Now

           //     },
           //       new FlightDTO()
           //     {
           //         Id = new Guid("9B854C0A-7951-40EF-9746-C6B0BD42258E"),
           //         FlightNumber = "RwasR@",
           //         ArrivateDateTime = DateTime.Now

           //     } };

           // ;
           // IEnumerable<FlightDTO> chai = flights.ToList();
            return View();
        
        }

        [HttpPost]
        public PartialViewResult AvailableFlights (Guid id)
        {

            //var flights = new List<FlightDTO>
            //{
            //    new FlightDTO()
            //    {
            //        Id = new Guid("060F7763-72B5-491E-B6C1-15D9A72E200E"),
            //        FlightNumber = "XRFCGT12",
            //        ArrivateDateTime = DateTime.Now,
            //        Faire = 200,

            //    },
            //     new FlightDTO()
            //    {
            //        Id = new Guid("65339990-C716-43F3-9846-2FA2D3C4DEDE"),
            //        FlightNumber = "MHYGH233",
            //        ArrivateDateTime = DateTime.Now,
            //        Faire = 400

            //    },
            //       new FlightDTO()
            //    {
            //        Id = new Guid("76A6A195-4A5B-45BA-B855-E05E5BD9DBD5"),
            //        FlightNumber = "Maxi2132",
            //        ArrivateDateTime = DateTime.Now,
            //        Faire = 564
                    

            //    },
            //      new FlightDTO()
            //    {
            //        Id = new Guid("9B854C0A-7951-40EF-9746-C6B0BD42258E"),
            //        FlightNumber = "RwasR@",
            //        ArrivateDateTime = DateTime.Now,
            //        Faire = 324

            //    } };

            //var flight = flights.Where(x => x.Id.Equals(id)).FirstOrDefault();

            var flightentity = new FlightDTO();
            //flight.Id = flight.Id;
            //flight.FlightNumber = flight.FlightNumber;

			
           // return Json(new { data = documents });
            return PartialView("_FlightAvailabilityModal");
          
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
