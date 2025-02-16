using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Services;

public interface IUserService{
    Task<UserInfoDto> GetUserInformation(string userId);
}