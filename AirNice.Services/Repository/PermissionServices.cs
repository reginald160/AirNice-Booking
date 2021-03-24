using AirNice.Data;
using AirNice.Models.Models;
using AirNice.Services.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using static AirNice.Services.Repository.GenenricServices;

namespace AirNice.Services.Repository
{
    public class PermissionServices :  GenericServices<Permission>, IPermissionServices
    {
        public PermissionServices(ApplicationDbContext context) : base(context)
        {
        }
    }
}
