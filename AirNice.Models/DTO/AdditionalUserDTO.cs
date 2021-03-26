using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
   public class AdditionalUserDTO : BaseDTO
    {
        public string Username { get; set; }
        public string Passcode { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
