using Application.Models.AuthenticationIdentity;

namespace WEB.Services
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/account/login", request);
            response.EnsureSuccessStatusCode(); // خطا را پرتاب می‌کند اگر وضعیت HTTP نشان‌دهنده‌ی خطا باشد
            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/account/register", request);
            response.EnsureSuccessStatusCode(); // خطا را پرتاب می‌کند اگر وضعیت HTTP نشان‌دهنده‌ی خطا باشد
            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }
    }
}
