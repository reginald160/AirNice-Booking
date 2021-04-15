using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Models.Enum;

namespace AirNice.Models.DTO
{
   public class TicketClassDTO : BaseDTO
    {
        public string Description { get; set; }
        public Guid PassengerId { get; set; }

        public TicketClassType TicketClassType { get; set; }
    }
}
