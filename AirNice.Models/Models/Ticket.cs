using System;
using System.Collections.Generic;

namespace AirNice.Models.Models
{
	public partial class Ticket: BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            this.PassengerTickets = new HashSet<PassengerTicket>();
            this.TicketFlights = new HashSet<TicketFlight>();
        }
        public double? Price { get; set; }
        public int? Discount { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string PaymentID { get; set; }
        public string Status { get; set; }
        public Guid? PassengerId { get; set; }
        public virtual Passenger Passenger { get; set; }
        public Guid? TicketClassId { get; set; }
		public virtual TicketClass TicketClass { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassengerTicket> PassengerTickets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TicketFlight> TicketFlights { get; set; }
    }
}
