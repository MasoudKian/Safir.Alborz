namespace Application.Models.AuthenticationIdentity
{
    public class JWTSetting
    {
        public string Key { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string DurationInMinutes { get; set; } = string.Empty;
    }
}
