using AirNice.Models.DTO;
using AirNice.Models.DTO.UserDTO;
using AirNice.Models.Models;
using AirNice.Utility.CoreHelpers;
using AirNiceWebMVC.Abstractions;
using AirNiceWebMVC.Helper;
using AirNiceWebMVC.ViewModel.User;
using EasyBanking.Utility.CoreHelpers;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        private readonly ILogger<UserController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly IWebHostEnvironment webHostEnvironment;
        private string UserSectionString;

        public UserController(IUserServices user, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<UserController> logger, IEmailSender emailSender, IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _user = user;
            _emailSender = emailSender;
            this.webHostEnvironment = webHostEnvironment;
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
        
        //[HttpPost]
        //public async Task<IActionResult> Register(RegisterDTO registerDTO, string userId, string userCode,string returnUrl = null)
        //{
        //    if(userCode != null)
        //    {
        //        return RedirectToAction("ConfirmEmail", new { userId = userId, code = userCode });
        //    }
        //    if(ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = registerDTO.Email, Email = registerDTO.Email };
        //        var password = registerDTO.Password;
        //        try
        //        {

        //             _user.Register(new RegisterViewModel { Email = registerDTO.Email, Password = registerDTO.Password}).GetAwaiter().GetResult();
        //            var result = await _userManager.CreateAsync(user, password);
        //            if (result.Succeeded)
        //            {
        //                _logger.LogInformation("User created a new account with password.");

        //                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        //                returnUrl = returnUrl ?? Url.Content("~/");
        //                code = LogicHelper.StringEncoder(code);
        //                var callbackUrl = Url.Page(
        //                    "/User/ConfirmEmail",
        //                    pageHandler: null,
        //                    values: new { Controller = "User", userId = user.Id, userCode = code, Url = returnUrl },
        //                    protocol: Request.Scheme);

        //                LogicHelper.MailSender(
        //                    user.Email,
        //                    "Confirm your email",
        //                     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

        //                if (_userManager.Options.SignIn.RequireConfirmedAccount)
        //                {
        //                    return RedirectToAction("RegisterConfirmation", new { email = user.Email });
        //                }
        //                else
        //                {
        //                    await _signInManager.SignInAsync(user, isPersistent: false);
        //                    return View("Home");
        //                }
        //            }
        //            foreach (var error in result.Errors)
        //            {
        //                ModelState.AddModelError(string.Empty, error.Description);

        //            }
        //        }
        //        catch(Exception exp)
        //        {
        //            _logger.LogInformation("Something went wrong");
        //            return View();
        //        }
               



        //    }
        //    return View();
        //}

        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO, string userCode = null, string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                _user.Register(new RegisterViewModel { Email = registerDTO.Email, Password = registerDTO.Password }).GetAwaiter().GetResult();
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
            LogicHelper.MailSender(
                user.Email,
                "Email Confirmation",
                "Your Email has been Confirmed you can now login into your account"
                );
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
                            LogicHelper.MailSender(user.Email, "Confirm your email",
                            $"Please confirm your account by   @:<a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>@:");
                        ViewBag.Message = user.Email;
                        return View("RegisterConfirmation");
                    }

                }


                var result = await _signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, loginDTO.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //_logger.LogInformation("User logged in.");
                    //var entity  = await _userManager.FindByEmailAsync(loginDTO.Email);
                    //if(entity.IsProfiled.Equals(true))
                    //    return RedirectToAction("Index", "Home");
                    //else
                    //{
                    //    var email = LogicHelper.StringEncoder(loginDTO.Email);
                    //    return RedirectToAction("UserProfile", new { email = email });
                    //}
                    HttpContext.Session.SetString(Universe.UserScetionSeed, loginDTO.Email);
                    return RedirectToAction("Index", "Home");
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

                LogicHelper.MailSender(
                     loginDTO.Email,
                    "Password Reset link",
                   $"Please reset your password by clicking the link   @:<a href='{callbackUrl}'></a>@:"

                    );
              

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
                    LogicHelper.MailSender(
                        user.Email,
                        "<h1>Password Reset Confrimation</h1>",
                        "Your Password has been reseted"
                        );
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
        [HttpGet]
        public IActionResult UserProfile(string email)
            {
            var emailValue = LogicHelper.StringDecoder(email);
            HttpContext.Session.SetString("email", emailValue);
            HttpContext.Session.GetString("email");
            ViewBag.Email = emailValue;
            var profileDTO = new ProfileDTO();
            profileDTO.Email = HttpContext.Session.GetString("email");

            return View(profileDTO);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UserProfile(ProfileDTO profile, HttpListenerRequest request)
        {
            if(ModelState.IsValid)
            {
                
                string referer = ControllerContext.HttpContext.Request.Headers["Referer"].ToString();
                Uri baseUri = new Uri(referer);
                 var imageurl =  UploadHelper.FileUpload(profile.Image, "images", webHostEnvironment.ToString());
                UserSectionString = HttpContext.Session.GetString(Universe.UserScetionSeed);
                var entity = await _userManager.FindByEmailAsync(UserSectionString);


                return Redirect(baseUri.AbsolutePath.ToString());
                
                    
            }

            return View();
        }

      

    }
}
