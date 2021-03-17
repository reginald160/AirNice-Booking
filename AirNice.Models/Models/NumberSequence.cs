using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
    public class NumberSequence : BaseModel
    {
        public string NumberSequenceName { get; set; }

        public string Module { get; set; }

        public string Prefix { get; set; }
        public int LastNumber { get; set; }
    }
}
