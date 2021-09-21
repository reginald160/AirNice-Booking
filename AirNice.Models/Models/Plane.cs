using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
    public partial class Plane : BaseModel2
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plane()
        {
            this.Flights = new HashSet<Flight>();
            this.PlaneAirports = new HashSet<PlaneAirport>();
            //this.PlaneSeatClasses = new HashSet<PlaneSeatClass>();
        }
        public string Airline { get; set; }
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight> Flights { get; set; }
        public int? SeatMapID { get; set; }
        public virtual SeatMap SeatMap { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaneAirport> PlaneAirports { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaneSeatClass> PlaneSeatClasses { get; set; }
    }
}
