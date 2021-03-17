using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public  class TicketClass : BaseModel
    {
        public string Description { get; set; }
        public Guid PassengerId { get; set; }
        [ForeignKey("PassengerId"), JsonIgnore]
        public Passenger Passenger { get; set; }
        public TicketClassType TicketClassType { get; set; }
    }
}
