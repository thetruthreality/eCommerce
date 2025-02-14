using ECommerceAPI.Services;
using ECommerceAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers;

  [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetCart(string userId)
        {
            return Ok(await _cartService.GetCartByUserIdAsync(userId));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartDto dto)
        {
            await _cartService.AddToCartAsync(dto.UserId, dto.ProductId, dto.Quantity);
            return Ok(new { message = "Product added to cart" });
        }

        [HttpDelete("remove")]
        public async Task<IActionResult> RemoveFromCart([FromQuery] string userId, int productId)
        {
            await _cartService.RemoveFromCartAsync(userId, productId);
            return Ok(new { message = "Product removed from cart" });
        }

        [HttpDelete("clear/{userId}")]
        public async Task<IActionResult> ClearCart(string userId)
        {
            await _cartService.ClearCartAsync(userId);
            return Ok(new { message = "Cart cleared" });
        }
    }