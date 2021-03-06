using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passcode { get; set; }
        public string RoleTitle { get; set; }
        public string Token { get; set; }
        public bool IsSuccessful { get; set; }
    }
}
