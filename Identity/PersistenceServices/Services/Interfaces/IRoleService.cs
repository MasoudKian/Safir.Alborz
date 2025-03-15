using Application.DTOs.IdentityAccount.AssignRole;
using Application.DTOs.IdentityAccount.Role;

namespace Identity.PersistenceServices.Services.Interfaces
{
    public interface IRoleService
    {
        Task<RolesResponseDTO> GetAllRoles();
        Task<bool> CreateRole(CreateRoleDTO role);
        Task<bool> EditRole(EditRoleDTO role); // متد جدید برای ویرایش

        Task<bool> DeactivateRole(string roleId); // متد جدید برای غیرفعال کردن
        Task<bool> IsRoleValid(string roleName); // متد جدید برای اعتبارسنجی نقش

        Task<List<UserDTO>> GetUsersAsync();
        Task<List<RoleDTO>> GetRolesAsync();


        Task<bool> AssignRoleToUser(AssignRoleToUserDTO model);
    }
}
