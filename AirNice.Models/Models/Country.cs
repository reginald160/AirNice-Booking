using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
	public class Country
	{
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public virtual ICollection<AirPort> Airports { get; set; }
        #endregion
    }
}
