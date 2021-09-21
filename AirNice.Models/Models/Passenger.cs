using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   
   public class Passenger : UserProfile
    {
        public string PassPort { get; set; }
        public string Address { get; set; }
		public string PassportNumber { get; set; }
		public DateTime? DateIssueOrExpiry { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }




    }
}
