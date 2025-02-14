using ECommerceAPI.DataBase.Models;
using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Repositories;

public interface IAuthRepository
{
     Task<IdentityResult> RegisterAsync(RegisterViewModel model);
     Task<ApplicationUser> FindUserByEmailAsync(string email);
     Task<bool> ValidateUserAsync(ApplicationUser user, string password);
     Task UpdateUserAsync(ApplicationUser user);
}