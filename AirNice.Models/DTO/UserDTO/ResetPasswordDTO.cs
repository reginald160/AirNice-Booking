using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirNice.Models.DTO.UserDTO
{
   public class ResetPasswordDTO
    {

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare("Password")]
        public string ComfirmPassword { get; set; }

        public string Code { get; set; }
        public string Email { get; set; }
        public string Time { get; set; }
    }
}
