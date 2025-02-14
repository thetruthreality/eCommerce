using ECommerceAPI.ViewModels;

namespace ECommerceAPI.Services;

public interface ICartService
{
    Task<CartDto> GetCartByUserIdAsync(string userId);
    Task AddToCartAsync(string userId, int productId, int quantity);
    Task RemoveFromCartAsync(string userId, int productId);
    Task ClearCartAsync(string userId);
}