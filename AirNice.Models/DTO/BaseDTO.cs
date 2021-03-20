using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
    public class BaseDTO
    {
        public Guid Id { get; set; }
        public bool Deleted { get; set; }
        public bool IsNewRecord { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
