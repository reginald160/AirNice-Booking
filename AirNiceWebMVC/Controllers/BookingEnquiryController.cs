﻿using AirNice.Services.WebServices.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWebMVC.Controllers
{
    public class BookingEnquiryController : BaseController
    {
        public BookingEnquiryController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

    }
}
