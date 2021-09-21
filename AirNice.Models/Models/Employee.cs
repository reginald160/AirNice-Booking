using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
    public class Employee : UserProfile
    {
        public string StaffCode { get; set; }
        public DateTime DateOfEmployment { get; set; }
        public DateTime DOB { get; set; }

        public bool HasResigned { get; set; }

        public Employee()
        {
            HasResigned = false;
        }
    }
}
