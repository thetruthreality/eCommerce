using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.Services;

namespace ECommerceAPI.ViewModels;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;

    public CartService(ICartRepository cartRepository)
    {
         _cartRepository = cartRepository;
    }

    public async Task AddToCartAsync(string userId, int productId, int quantity)
    {
         await _cartRepository.AddToCartAsync(userId, productId, quantity);
    }

    public async Task ClearCartAsync(string userId)
    {
       await _cartRepository.ClearCartAsync(userId);
    }

    public async Task<CartDto> GetCartByUserIdAsync(string userId)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            return new CartDto
            {
                UserId = userId,
                CartItems = cart?.CartItems.Select(ci => new CartItemDto
                {
                    ProductId = ci.ProductId,
                    ProductName = ci.Product.Name,
                    Price = ci.Product.Price,
                    Quantity = ci.Quantity
                }).ToList() ?? new List<CartItemDto>(),
                TotalPrice = cart?.TotalPrice ?? 0
            };
    }

    public async Task RemoveFromCartAsync(string userId, int productId)
    {
       await _cartRepository.RemoveFromCartAsync(userId, productId);
    }
}