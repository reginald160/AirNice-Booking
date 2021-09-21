using System.Collections.Generic;

namespace AirNice.Models.Models
{
	public class SeatMap : BaseModel2
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeatMap()
        {
            this.Planes = new HashSet<Plane>();
        }

        public string Name { get; set; }
        public string Columns { get; set; }
        public string RowWithoutSeat { get; set; }
        public int? Capacity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Plane> Planes { get; set; }
    }
}