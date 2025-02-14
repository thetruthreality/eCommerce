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
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;
    public AuthService(IAuthRepository authRepository, IConfiguration configuration)
    {
        _authRepository = authRepository;
        _configuration = configuration;
    }

    public async Task<AuthResponseViewModel> LoginAsync(LoginViewModel model)
    {
     var user = await _authRepository.FindUserByEmailAsync(model.Email);
            if (user != null && await _authRepository.ValidateUserAsync(user, model.Password))
            {
                var token = GenerateJwtToken(user);
                var refreshToken = GenerateRefreshToken();
                
                user.RefreshToken = refreshToken;
                user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
                await _authRepository.UpdateUserAsync(user);

                return new AuthResponseViewModel { Token = token, RefreshToken = refreshToken };
            }
            return null;
    }

    public Task<AuthResponseViewModel?> RefreshTokenAsync(string token)
    {
        throw new NotImplementedException();
    }

    public async Task<string> RegisterAsync(RegisterViewModel registerViewModel)
    {
        var result = await _authRepository.RegisterAsync(registerViewModel);
        return result.Succeeded ? "User registered successfully!" : string.Join(", ", result.Errors.Select(e => e.Description));
    }

    private string GenerateJwtToken(IdentityUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.NameIdentifier, user.Id)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["JwtSettings:Issuer"],
            _configuration["JwtSettings:Audience"],
            claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}