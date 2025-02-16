using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.Repositories;
using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
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


            return new AuthResponseViewModel { Token = newAccessToken, RefreshToken = newRefreshToken };
    }

    public async Task<string> RegisterAsync(RegisterViewModel registerViewModel)
    {
        var result = await _authRepository.RegisterAsync(registerViewModel);
        return  result.Succeeded ? "User registered successfully!" : string.Join(", ", result.Errors.Select(e => e.Description));
    }

    // private string GenerateJwtToken(IdentityUser user)
    // {
    //     var claims = new List<Claim>
    //     {
    //         new Claim(JwtRegisteredClaimNames.Sub, user.Id),
    //         new Claim(JwtRegisteredClaimNames.Email, user.Email),
    //         new Claim(ClaimTypes.NameIdentifier, user.Id)
    //     };

    //     var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
    //     var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    //     var token = new JwtSecurityToken(
    //         _configuration["JwtSettings:Issuer"],
    //         _configuration["JwtSettings:Audience"],
    //         claims,
    //         expires: DateTime.UtcNow.AddHours(1),
    //         signingCredentials: creds
    //         );

    //         return new JwtSecurityTokenHandler().WriteToken(token);
    // }

    // private string GenerateRefreshToken()
    // {
    //     var randomNumber = new byte[32];
    //     using var rng = RandomNumberGenerator.Create();
    //     rng.GetBytes(randomNumber);
    //     return Convert.ToBase64String(randomNumber);
    // }
}