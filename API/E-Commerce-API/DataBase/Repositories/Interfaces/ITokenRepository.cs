using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.DataBase.Repositories;

public interface ITokenRepository
    {
        Task SaveRefreshToken(IdentityUser user, string refreshToken);
        Task<string> GetRefreshToken(IdentityUser user);
    }