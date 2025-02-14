using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ECommerceAPI.Services;
using ECommerceAPI.ViewModels;
using System.Security.Claims;
namespace ECommerceAPI.Controllers;

[Route("api/auth")]
[ApiController]  
public class LoginController : ControllerBase
{
    private readonly IAuthService _authService;   
     public LoginController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
    {
        var result = await _authService.RegisterAsync(model);
        return Ok(new { message = result });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginViewModel model)
    {
      var result = await _authService.LoginAsync(model);
      if (result == null)
        return Unauthorized(new { message = "Invalid email or password" });

    return Ok(result);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshRequestModel model)
    {
        var result = await _authService.RefreshTokenAsync(model.RefreshToken);
        if (result == null)
            return Unauthorized(new { message = "Invalid refresh token" });

        return Ok(result);
    }

    [Authorize]
    [HttpGet("user")]
    public IActionResult GetCurrentUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Ok(new { userId });
    }
    
}