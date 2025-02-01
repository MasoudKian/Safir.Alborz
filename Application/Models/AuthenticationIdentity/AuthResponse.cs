namespace Application.Models.AuthenticationIdentity
{
    public class AuthResponse
    {
        public string Id { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        //public string Code { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;

        public string RedirectUrl { get; set; } = string.Empty; // ✅ مسیر هدایت کاربر بعد از لاگین
    }
}
