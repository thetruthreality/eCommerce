using ECommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/[controller]")]
[ApiController]
public class CheckoutController :ControllerBase
{
    private readonly ICheckoutService _checkoutService;
    public CheckoutController(ICheckoutService checkoutService)
    {
        _checkoutService = checkoutService;
    }

    [HttpGet]
    [Route("preview/{userId}")]
    public async Task<IActionResult> GetCheckoutPreview(string userId)
    {
        var preview = await _checkoutService.GetCheckoutPreviewAsync(userId);
        return Ok(preview);
    }
}