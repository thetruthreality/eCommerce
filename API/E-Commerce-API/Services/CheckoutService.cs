using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.DTOs;

namespace ECommerceAPI.Services;

public class CheckoutService : ICheckoutService
{
    private readonly ICartRepository _cartRepository;

    public CheckoutService(ICartRepository cartRepository)
    {
         _cartRepository = cartRepository;
    }

    public async Task<CheckoutPreviewDto> GetCheckoutPreviewAsync(string userId)
    {
        var cart = await _cartRepository.GetCartByUserIdAsync(userId);
            if (cart == null || !cart.CartItems.Any())
                return new CheckoutPreviewDto { CartItems = new List<CartItemDto>(), TotalAmount = 0 };

            var cartItems = cart.CartItems.Select(ci => new CartItemDto
            {
                ProductId = ci.ProductId,
                ProductName = ci.Product.Name,
                Price = ci.Product.Price,
                Quantity = ci.Quantity
            }).ToList();

            return new CheckoutPreviewDto
            {
                CartItems = cartItems,
                TotalAmount = cartItems.Sum(ci => ci.TotalPrice)
            };
    }
}