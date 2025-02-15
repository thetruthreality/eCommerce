using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Services;

public interface ITokenService
{
    Task<string> GenerateAccessToken(IdentityUser user);
    Task<string> GenerateRefreshToken(IdentityUser user);
}