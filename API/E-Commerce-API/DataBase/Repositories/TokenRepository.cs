using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.DataBase.Repositories;

 public class TokenRepository : ITokenRepository
    {
        private readonly UserManager<IdentityUser> _userManager;

        public TokenRepository(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task SaveRefreshToken(IdentityUser user, string refreshToken)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, "ECommerceAPI", "RefreshToken");
            await _userManager.SetAuthenticationTokenAsync(user, "ECommerceAPI", "RefreshToken", refreshToken);
        }

        public async Task<string> GetRefreshToken(IdentityUser user)
        {
            return await _userManager.GetAuthenticationTokenAsync(user, "ECommerceAPI", "RefreshToken");
        }
    }