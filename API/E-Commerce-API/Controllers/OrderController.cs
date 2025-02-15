using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Services;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceAPI.Controllers;
[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/order")]
[ApiController]

 public class OrderController : ControllerBase
{
    private readonly IOrderService _orderService;

    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    [Route("checkout/{userId}")]
    public async Task<IActionResult> Checkout(string userId)
    {
        var order = await _orderService.CreateOrderAsync(userId);
         return Ok(new { message = "Order placed successfully", order });
    }

    [HttpGet("{orderId}")]
    public async Task<IActionResult> GetOrder(int orderId)
    {
        return Ok(await _orderService.GetOrderByIdAsync(orderId));
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetUserOrders(string userId)
    {
        return Ok(await _orderService.GetOrdersByUserIdAsync(userId));
    }
    }