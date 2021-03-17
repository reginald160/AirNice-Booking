using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
    public class PassengerDTO : BaseModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
    }
}
