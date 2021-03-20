using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Utility.CoreHelpers
{
    public static class StaticDetails
    {
        public static string BaseUrl = Universe.APIBaseUrl;
        public static string PassengerUrl = BaseUrl + "/api/Passenger";
        public static string BookingEnquiryUrl =  BaseUrl + "/api/BookingEnquiry";



    }
}
