using Infirmary.Models.Authenticate;
using Blazored.LocalStorage;
namespace Infirmary.Services
{

    public class AuthService
    {
        private readonly ILocalStorageService _localStorage;

        public AuthService(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public bool IsAuthenticated { get; private set; }

        public async Task<AuthResult> LoginAsync(string username, string password, bool rememberMe)
        {
            // نمونه ساده—در عمل اینجا باید به API بک‌اند وصل شوید
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "123456")
            {
                IsAuthenticated = true;

                if (rememberMe)
                    await _localStorage.SetItemAsync("auth_token", Guid.NewGuid().ToString());

                return new AuthResult(true);
            }

            return new AuthResult(false, "نام کاربری یا رمز عبور اشتباه است");
        }

        public async Task LogoutAsync()
        {
            IsAuthenticated = false;
            await _localStorage.RemoveItemAsync("auth_token");
        }
    }

}
