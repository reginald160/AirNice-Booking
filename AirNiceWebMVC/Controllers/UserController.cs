using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNiceWebMVC.Abstractions;
using AirNiceWebMVC.Helper;
using EasyBanking.Utility.CoreHelpers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServices _user;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ApplicationUser> _logger;
        private readonly IEmailSender _emailSender;
        public UserController(IUserServices user, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<ApplicationUser> logger, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _user = user;
            _emailSender = emailSender;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public IActionResult Login(string userId, string code)
        {

            if (userId == String.Empty || code == null)
                return View();
            else
            {

                return RedirectToAction("ConfirmEmail", new { userId = userId, code = code });
            }
           
        }

        [HttpGet]
        public IActionResult Register(string userId, string code)
        {

            if(userId == String.Empty || code == null)
                return View();
            else
            {

                return RedirectToAction("ConfirmEmail", new { userId  = userId , code = code });
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO, string returnUrl = null )
        {
            if(ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = registerDTO.Email, Email = registerDTO.Email };
                var password = registerDTO.Password;
                var result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    returnUrl = returnUrl ?? Url.Content("~/");
                    code = LogicHelper.StringEncoder(code);
                    var callbackUrl = Url.Page(
                        "/User/ConfirmEmail",
                        pageHandler: null,
                        values: new { Controller = "User",  userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);
                    var number = callbackUrl;
                    //await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                  
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToAction("RegisterConfirmation", new { email = user.Email});
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return View("Home");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }



            }
            return View();
        }


        public   IActionResult RegisterConfirmation(string email)
        {
            ViewBag.Message = email;


            return View();
        }
        
            public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }
            if (user.EmailConfirmed.Equals(true))
            {
                return RedirectToAction("Index", "Home");
            }

            code = LogicHelper.StringDecoder(code); ;
            var result = await _userManager.ConfirmEmailAsync(user, code);
            ViewBag.Message = result.Succeeded ? "Thank you for confirming your email , Kindly login to your account." : "Error confirming your email.";
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
        public async Task< IActionResult> Login(LoginDTO loginDTO, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if(user != null)
                {
                    if (user.EmailConfirmed.Equals(false))
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        returnUrl = returnUrl ?? Url.Content("~/");
                        code = LogicHelper.StringEncoder(code);
                        var callbackUrl = Url.Page(
                            "/User/ConfirmEmail",
                            pageHandler: null,
                            values: new { Controller = "User", userId = user.Id, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);
                        var number = callbackUrl;
                        //await _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                        //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                        ViewBag.Message = user.Email;
                        return View("RegisterConfirmation");
                    }

                }


                var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, loginDTO.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {   
                    _logger.LogInformation("User logged in.");
                    var entity  = await _userManager.FindByEmailAsync(loginDTO.Email);
                    if(entity.IsProfiled.Equals(true))
                        return RedirectToAction("Index", "Home");
                    else
                    {
                        var email = LogicHelper.StringEncoder(loginDTO.Email);
                        return RedirectToAction("Profile", new { email = email });
                    }
                    
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

            return View();

        }


       [HttpGet]
        public async Task< IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult ForgetPassword(string code, string email, string time)
        {
            if(code == null)
                return View();
            return RedirectToAction("ResetPassword", new { code = code, email = email, time = time});
        }


        [HttpPost]
        public async Task<IActionResult> ForgetPassword(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginDTO.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    ViewBag.Message = "User does not exist";
                    return View();
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = LogicHelper.StringEncoder(code);
                var startIme = LogicHelper.StringEncoder(DateTime.Now.ToString());
                var email = LogicHelper.StringEncoder(loginDTO.Email);

                var callbackUrl = Url.Page(
                    "/User/ResetPassword",
                    pageHandler: null,
                    values: new { Controller = "User", code , email = email, time = startIme},
                    protocol: Request.Scheme);

                //await _emailSender.SendEmailAsync(
                //    loginDTO.Email,
                //    "Reset Password",
                //    $"Please reset your password by <a href='{callbackUrl}'>clicking here</a>.");

                ViewBag.Message = user.Email;
                return View("RegisterConfirmation");
            }

            return View();

        }

        public IActionResult ResetPassword(string code, string email, string time)
        {
            var Email = LogicHelper.StringDecoder(email);
            var Code = LogicHelper.StringDecoder(code);
            var startTime = LogicHelper.StringDecoder(time);


            ViewBag.Time = startTime;
            ViewBag.Code = code;
            ViewBag.Email = email;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            if (ModelState.IsValid)
            {
                var linkExpire = LogicHelper.TimeExpire(resetPasswordDTO.Time);
                if (linkExpire.Equals(true))
                    return RedirectToAction("LinkExpiry");

                var password = resetPasswordDTO.Password;
                var user = await _userManager.FindByEmailAsync(resetPasswordDTO.Email);
                var code = resetPasswordDTO.Code;
            

            var result = await _userManager.ResetPasswordAsync(user, code, password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            }
            return View();
        }
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        public IActionResult LinkExpiry()
        {
            return View();
        }

        public IActionResult Profile(string email)
        {
            ViewBag.Email = LogicHelper.StringDecoder(email);

            return View();
        }


        //public async Task< IActionResult> Profile(string email)
        //{
        //    ViewBag.Email = LogicHelper.StringDecoder(email);

        //    return View();
        //}

    }
}
