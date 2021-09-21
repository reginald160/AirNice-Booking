using System;

namespace AirNice.Models.Models
{
	public class PlaneSeatClass : BaseModel2
	{
        public int? Capacity { get; set; }
        public double? Price { get; set; }
        public int? Order { get; set; }
        public int? PlaneID { get; set; }
        public virtual Plane Plane { get; set; }
        public int? SeatClassID { get; set; }
        public virtual SeatClass SeatClass { get; set; }
    }
}