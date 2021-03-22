using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.DTO
{
    public class PassengerDTO : BaseDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public byte[] picture { get; set; }
        public DateTime DOB { get; set; }
        public string UserId { get; set; }
    }
}
