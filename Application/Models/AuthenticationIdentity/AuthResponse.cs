namespace Application.Models.AuthenticationIdentity
{
    public class AuthResponse
    {
        public int Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
