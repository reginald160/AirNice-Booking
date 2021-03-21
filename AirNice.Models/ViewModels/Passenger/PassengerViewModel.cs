using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.ViewModels.Passenger
{
    public class PassengerViewModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
        public byte[] picture { get; set; }
    }
}
