
using AutoMapper;
using ECommerceAPI.Database;
using ECommerceAPI.DataBase.Models;
using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ApplicationDbContext _context;
    private IMapper _mapper;    
    public AuthRepository(UserManager<IdentityUser> userManager,
    IMapper mapper,
    ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;  
        _mapper = mapper;
    }

    public async Task<UserInfoDto> FindUserByEmailAsync(string email)
    {
        return _mapper.Map<UserInfoDto>( 
            await _context.Users.FirstOrDefaultAsync(u => u.Email == email));
    }

    public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
    {
        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        return await _userManager.CreateAsync(user, model.Password);
    }

    public async Task UpdateUserAsync(ApplicationUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> ValidateUserAsync(ApplicationUser user, string password)
    {
        return await _userManager.CheckPasswordAsync(user, password);
    }
}