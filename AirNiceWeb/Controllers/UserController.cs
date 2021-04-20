using AirNice.Models.DTO.UserDTO;
using AirNiceWeb.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _user;

        public UserController(IUserServices user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginDTO loginDTO)
        {
            if(ModelState.IsValid)
            {
              var user = await _user.Login(loginDTO);
                var token = user.Token;
                if(user.Token == null)
                {
                    ViewBag.Message = "Invalid login details";
                    return View();
                }
                HttpContext.Session.SetString("Token", token);
                    return Redirect("~/Dashboard/Index");
            }
            return View();

        }
    }
}
