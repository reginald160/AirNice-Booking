using AirNice.Models.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.DTO
{
    public class PassengerDTO : BaseDTO
    {
        //[GlobalName,Required]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber), Required]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }
        [DataType(DataType.Password), Required]
        public string Password { get; set; }
        //[Compare("Password")]
        //[DataType(DataType.Password), Required]
        public string ConfirmPassword { get; set; }
        public string PassPort { get; set; }
        public string Address { get; set; }
        [JsonIgnore]
        public byte[] picture { get; set; }
        [DataType(DataType.Date), Required]
        public DateTime DOB { get; set; }
        public string UserId { get; set; }
    }
}
