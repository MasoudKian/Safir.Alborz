namespace Application.DTOs.IdentityAccount.AssignRole
{
    public class AssignRoleViewModel
    {
        public List<UserDTO> Users { get; set; } = new();
        public List<RoleDTO> Roles { get; set; } = new();
    }
}
