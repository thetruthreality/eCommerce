using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerceAPI.Services;
using ECommerceAPI.ViewModels;
using System.Security.Claims;
using System.Threading.Tasks;
namespace ECommerceAPI.Controllers;

[Route("api/auth")]
[ApiController]  
public class LoginController : ControllerBase
{
    private readonly IAuthService _authService;   
    private readonly IUserService _userService;
     public LoginController(IAuthService authService,
     IUserService userService
     )
    {
        _authService = authService;
        _userService = userService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        var result = await _authService.RegisterAsync(model);
        return Ok(new { message = "result" });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
      var result = await _authService.LoginAsync(model);
      if (result == null)
        return Unauthorized(new { message = "Invalid email or password" });

    return Ok(result);
    }

        [HttpPost("logout")]
    public async Task<IActionResult> Logout([FromBody] LogoutDto model)
    {
      var result = await _authService.LogOutAsync(model);
      if (result == null)
        return Unauthorized(new { message = "Invalid email or password" });

    return Ok(result);
    }



    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshRequestDto model)
    {
        var result = await _authService.RefreshTokenAsync(model);
        if (result == null)
            return Unauthorized(new { message = "Invalid refresh token" });

        return Ok(result);
    }

    [Authorize(AuthenticationSchemes = "Bearer")]  
    [HttpGet("user")]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
       return Ok( await _userService.GetUserInformation(userId));
    }
    
}