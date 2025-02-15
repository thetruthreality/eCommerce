
using ECommerceAPI.Database;
using ECommerceAPI.DataBase.Models;
using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;

    public AuthRepository(UserManager<IdentityUser> userManager,ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<ApplicationUser> FindUserByEmailAsync(string email)
    {
        return null; //await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task UpdateUserAsync(ApplicationUser user)
    {
        _context.Users.Update(user);
        await _userManager.RemoveAuthenticationTokenAsync(user,"ECommerceAPI","RefreshToken");
        await _userManager.SetAuthenticationTokenAsync(user, "ECommerceAPI", "RefreshToken", user.RefreshToken);

        await _context.SaveChangesAsync();
    }

    public async Task<bool> ValidateUserAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
}