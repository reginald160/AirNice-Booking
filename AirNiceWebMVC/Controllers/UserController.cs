using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNiceWebMVC.Abstractions;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _user;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ApplicationUser> _logger;
        public UserController(IUserServices user, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<ApplicationUser> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            return View();
        }
        [HttpGet]
        public IActionResult OTPValidation()
        {
            return View();
        }

        [HttpGet]
        public IActionResult OTP()
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> Login(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {        
                var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, loginDTO.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return RedirectToAction("Index");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToAction("/Lockout");
                }
                else
                {
                    ViewBag.Message = "Invalid login attempt.";
                    return View();
                }
            }



            //if(ModelState.IsValid)
            //{
            //  var user = await _user.Login(loginDTO);
            //    var token = user.Token;
            //    if(user.Token == null)
            //    {
            //        ViewBag.Message = "Invalid login details";
            //        return View();
            //    }
            //    HttpContext.Session.SetString("Token", token);
            //        return Redirect("~/Dashboard/Index");
            //}
            return View();

        }
    }
}
