namespace Application.DTOs.Account
{
    public class LoginVM
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public bool RemeberMe { get; set; }
    }
}
