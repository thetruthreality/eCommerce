
using ECommerceAPI.ViewModels;

namespace ECommerceAPI.Services;

public interface IAuthService
{
    Task<string> RegisterAsync(RegisterViewModel registerViewModel);
    Task<AuthResponseViewModel> LoginAsync(LoginViewModel model);
    Task<AuthResponseViewModel?> RefreshTokenAsync(string token);

}