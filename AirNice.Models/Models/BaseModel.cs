using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            DateModified = DateTime.Now;
        }
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool IsNewRecord { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
