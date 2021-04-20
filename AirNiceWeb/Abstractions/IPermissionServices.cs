using AirNice.Models.DTO;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirNiceWeb.Abstractions
{
    public interface IPermissionServices
    {

        [Get("/Permission/Index")]
        Task<List<PermissionDTO>> GetPermissions();
        [Get("/Permission/Trash")]
        Task<List<PermissionDTO>> GetPermissionsFromTrash();

        [Post("/Permission/GetPermission")]
        Task<PermissionDTO> GetPermission(Guid id);

        [Post("/Permission/Create")]
        Task<PermissionDTO> AddPermission(PermissionDTO permissionDTO);
        [Post("/Permission/Update")]
        Task<PermissionDTO> UpdatePassenger(Guid id, PermissionDTO permissionDTO);
        [Post("/Permission/DeleteAndRetrieve")]
        Task Delete(Guid id);
    }
}
