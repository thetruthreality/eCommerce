
using ECommerceAPI.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Services;

public interface IAuthService
{
   Task<string> RegisterAsync(RegisterViewModel registerViewModel);
   Task<AuthResponseViewModel> LoginAsync(LoginViewModel model);
   Task<IdentityResult> LogOutAsync(LogoutDto model);
   Task<AuthResponseViewModel> RefreshTokenAsync(RefreshRequestDto request);


}