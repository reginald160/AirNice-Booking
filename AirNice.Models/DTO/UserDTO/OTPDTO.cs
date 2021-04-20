using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AirNice.Models.DTO.UserDTO
{
   public class OTPDTO
    {
        [Display(Name ="Phone Number"), Required, DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
