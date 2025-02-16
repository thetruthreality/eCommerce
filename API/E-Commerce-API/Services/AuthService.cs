using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.Repositories;
using ECommerceAPI.DTOs;
using Microsoft.AspNetCore.Identity;
namespace ECommerceAPI.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;
    private readonly ITokenRepository _tokenRepository;
    private readonly IAuthRepository _authRepository;
    public AuthService(UserManager<IdentityUser> userManager, 
    ITokenService tokenService, 
    ITokenRepository tokenRepository,
    IAuthRepository authRepository)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _tokenRepository = tokenRepository;
        _authRepository = authRepository;
    }

    public async Task<AuthResponseViewModel> LoginAsync(LoginViewModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);
        if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
        {
            return null;
        }

        var accessToken = await _tokenService.GenerateAccessToken(user);
        var refreshToken = await _tokenService.GenerateRefreshToken(user);

        return new AuthResponseViewModel { Token = accessToken, RefreshToken = refreshToken, UserId= user.Id };

    }

    public async Task<IdentityResult> LogOutAsync(LogoutDto model)
    {
        var user = await _userManager.FindByEmailAsync(model.UserId);
        if (user == null) return null;

    // Remove refresh token from DB (Assuming stored in AspNetUserTokens)
       var data= await _userManager.RemoveAuthenticationTokenAsync(user, "ECommerceAPI", "RefreshToken");

        return data;
    }

    public async Task<AuthResponseViewModel?> RefreshTokenAsync(RefreshRequestDto request)
    {
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
            return null;

        var savedRefreshToken = await _tokenRepository.GetRefreshToken(user);
        if (savedRefreshToken != request.RefreshToken)
            return null;

        var newAccessToken = await _tokenService.GenerateAccessToken(user);
        var newRefreshToken = await _tokenService.GenerateRefreshToken(user);


            return new AuthResponseViewModel { Token = newAccessToken, RefreshToken = newRefreshToken,UserId= user.Id };
    }

    public async Task<string> RegisterAsync(RegisterViewModel registerViewModel)
    {
        var result = await _authRepository.RegisterAsync(registerViewModel);
        return  result.Succeeded ? "User registered successfully!" : string.Join(", ", result.Errors.Select(e => e.Description));
    }
}