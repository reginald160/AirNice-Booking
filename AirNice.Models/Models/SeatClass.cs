using System.Collections.Generic;

namespace AirNice.Models.Models
{
	public class SeatClass : BaseModel2
	{
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeatClass()
        {
            this.PlaneSeatClasses = new HashSet<PlaneSeatClass>();
        }
        public string Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaneSeatClass> PlaneSeatClasses { get; set; }
    }
}