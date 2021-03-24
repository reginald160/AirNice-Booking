using System;
using System.Collections.Generic;
using System.Text;

namespace AirNice.Models.DTO
{
   public class PermissionDTO : BaseDTO
    {
        public string Title { get; set; }
        public string Module { get; set; }
        public string Description { get; set; }
        public Guid RoleId { get; set; }
    }
}
