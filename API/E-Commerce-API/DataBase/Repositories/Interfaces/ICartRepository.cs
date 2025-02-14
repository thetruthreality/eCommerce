using ECommerceAPI.DataBase.Models;

namespace ECommerceAPI.DataBase.Repositories;

public interface ICartRepository
{
     Task<Cart?> GetCartByUserIdAsync(string userId);
    Task AddToCartAsync(string userId, int productId, int quantity);
    Task RemoveFromCartAsync(string userId, int productId);
    Task ClearCartAsync(string userId);
    Task<decimal> GetCartTotalPriceAsync(string userId);
}