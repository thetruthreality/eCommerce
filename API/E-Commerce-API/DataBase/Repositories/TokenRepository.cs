using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace ECommerceAPI.DataBase.Repositories;

 public class TokenRepository : ITokenRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        public TokenRepository(UserManager<IdentityUser> userManager,
        IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task SaveRefreshToken(IdentityUser user, string refreshToken)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, _jwtSettings.Issuer,_jwtSettings.TokenName);
            await _userManager.SetAuthenticationTokenAsync(user, _jwtSettings.Issuer,_jwtSettings.TokenName,refreshToken);
        }

        public async Task<string> GetRefreshToken(IdentityUser user)
        {
            return await _userManager.GetAuthenticationTokenAsync(user, _jwtSettings.Issuer, _jwtSettings.TokenName);
        }
    }