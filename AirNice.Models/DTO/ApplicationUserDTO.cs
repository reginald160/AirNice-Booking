using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
