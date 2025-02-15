using Application.DTOs.IdentityAccount.Role;

namespace Identity.PersistenceServices.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RolesResponseDTO> GetAllRoles();
        Task<bool> CreateRole(CreateRoleDTO role);
    }
}
