using Application.Models.AuthenticationIdentity;
using Microsoft.Extensions.Options;
using NuGet.Configuration;
using WEB.Models.Api;

namespace WEB.Services
{
    public class AuthWebServices
    {
        private readonly HttpClient _httpClient;

        public AuthWebServices(HttpClient httpClient, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl); // آدرس API خود را اینجا تنظیم کنید
            // https://localhost:7156/scalar/v1
        }

        public async Task<AuthResponse> LoginAsync(AuthRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Auth/login", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<AuthResponse>();
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/Auth/register", request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<RegisterResponse>();
        }
    }
}
