using Application.Contracts.Interfaces.APIs;
using Application.DTOs.IdentityAccount;
using System.Security.Claims;

namespace WEB.Services.IdentityAPIs
{
    public class AuthIdentityAPIService : IAuthIdentityAPIService
    {
        private readonly HttpClient _httpClient;

        public AuthIdentityAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            //_httpClient.BaseAddress = new Uri(apiSettings.Value.BaseUrl); // آدرس API خود را اینجا تنظیم کنید
            // https://localhost:7156/scalar/v1
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("api/v1/auth/register", request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> LoginAsync(AuthLoginRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7156/api/AuthIdentity/login", request);
            return response.IsSuccessStatusCode;
        }

        public async Task LogoutAsync()
        {
            await _httpClient.PostAsync("api/v1/auth/logout", null);
        }

        public async Task<bool> IsInRoleAsync(string roleName)
        {
            // ایجاد یک شی برای ارسال به API
            var request = new { RoleName = roleName };

            // ارسال درخواست به API
            var response = await _httpClient.PostAsJsonAsync("api/v1/auth/is-in-role", request);

            // اگر پاسخ موفقیت‌آمیز باشد، محتوای آن را به boolean تبدیل کنید
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return bool.Parse(content);
            }

            return false; // در صورت خطا false بازگردانید
        }

    }
}
