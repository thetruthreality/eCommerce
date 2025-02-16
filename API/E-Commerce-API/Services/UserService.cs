using System.Threading.Tasks;
using AutoMapper;
using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IMapper _mapper;
    public UserService(UserManager<IdentityUser> userManager,
    IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<UserInfoDto> GetUserInformation(string userId)
    {
       return _mapper.Map<UserInfoDto>(await  _userManager.FindByIdAsync(userId));
    }
}