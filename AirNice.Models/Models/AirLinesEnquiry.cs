using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.Models
{
   public class AirLinesEnquiry : BaseModel
    {
        public string Title { get; set; }
        public AirLinesEnquiryType AirLinesEnquiryType { get; set; }
        public string Description { get; set; }

    }
}
