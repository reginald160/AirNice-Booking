using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
    public class Bank : BaseModel
    {
        public long AccountNumber { get; set; }
        public string AccountName { get; set; }
    }
}
