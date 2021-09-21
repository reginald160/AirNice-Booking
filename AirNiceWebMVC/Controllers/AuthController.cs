using AirNice.Models.DTO.UserDTO;
using AirNiceWebMVC.Abstractions;
using AirNiceWebMVC.ViewModel.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserServices _userServices;

        public AuthController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userServices.Register(viewModel);
               
                //try
                //{
                    
                //    if (result.Succeeded)
                //    {
                //        _logger.LogInformation("User created a new account with password.");

                //        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //        returnUrl = returnUrl ?? Url.Content("~/");
                //        code = LogicHelper.StringEncoder(code);
                //        var callbackUrl = Url.Page(
                //            "/User/ConfirmEmail",
                //            pageHandler: null,
                //            values: new { Controller = "User", userId = user.Id, userCode = code, Url = returnUrl },
                //            protocol: Request.Scheme);

                //        LogicHelper.MailSender(
                //            user.Email,
                //            "Confirm your email",
                //             $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                //        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                //        {
                //            return RedirectToAction("RegisterConfirmation", new { email = user.Email });
                //        }
                //        else
                //        {
                //            await _signInManager.SignInAsync(user, isPersistent: false);
                //            return View("Home");
                //        }
                //    }
                //    foreach (var error in result.Errors)
                //    {
                //        ModelState.AddModelError(string.Empty, error.Description);

                //    }
                //}
                //catch (Exception exp)
                //{
                //    return View();
                //}




            }
            return View();
        }
    }
}
