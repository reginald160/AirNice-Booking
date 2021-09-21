using System.Collections.Generic;

namespace AirNice.Models.Models
{
	public partial class PassengerType : BaseModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PassengerType()
        {
            this.PassengerTickets = new HashSet<PassengerTicket>();
        }
        public string Name { get; set; }
        public int? Discount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PassengerTicket> PassengerTickets { get; set; }
    }
}