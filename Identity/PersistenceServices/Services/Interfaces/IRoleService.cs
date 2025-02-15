using Application.DTOs.IdentityAccount.AssignRole;
using Application.DTOs.IdentityAccount.Role;

namespace Identity.PersistenceServices.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RolesResponseDTO> GetAllRoles();
        Task<bool> CreateRole(CreateRoleDTO role);

        Task<List<UserDTO>> GetUsersAsync();
        Task<List<RoleDTO>> GetRolesAsync();


        Task<bool> AssignRoleToUser(AssignRoleToUserDTO model);
    }
}
