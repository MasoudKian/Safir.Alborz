using Application.Models.AuthenticationIdentity;

namespace WEB.Services
{
    public class AuthServices
    {
        private readonly HttpClient _httpClient;

        public AuthServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri("https://localhost:7235/"); // آدرس API خود را اینجا تنظیم کنید
            // https://localhost:7156/scalar/v1
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7156/api/v1/Auth/login", request);
            response.EnsureSuccessStatusCode(); // خطا را پرتاب می‌کند اگر وضعیت HTTP نشان‌دهنده‌ی خطا باشد
            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7156/api/v1/Auth/register", request);
            response.EnsureSuccessStatusCode(); // خطا را پرتاب می‌کند اگر وضعیت HTTP نشان‌دهنده‌ی خطا باشد
            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }
    }
}
