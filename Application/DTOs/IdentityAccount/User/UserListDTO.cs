namespace Application.DTOs.IdentityAccount.User
{
    public class UserListDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
    }
}
