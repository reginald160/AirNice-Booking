using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Utility.Response
{
    public class ResponseMessage
    {
      
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
        public object Data { get; set; }

    }
}
