using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AirNice.Models.Models
{
   public  class AirPort 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirPort()
        {
            this.PlaneAirports = new HashSet<PlaneAirport>();
        }
		public int ID { get; set; }
		public string Name { get; set; }
        public string City { get; set; }
        public int? CountryID { get; set; }

        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaneAirport> PlaneAirports { get; set; }

    }
}
