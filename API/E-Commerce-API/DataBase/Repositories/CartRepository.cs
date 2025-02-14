using ECommerceAPI.Database;
using ECommerceAPI.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.DataBase.Repositories;

public class CartRepository : ICartRepository
{
    private readonly ApplicationDbContext _context;
    public CartRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddToCartAsync(string userId, int productId, int quantity)
    {
        var cart = await GetCartByUserIdAsync(userId);
        if (cart == null)
        {
            cart = new Cart { UserId = userId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (cartItem != null)
        {
            cartItem.Quantity += quantity;
        }
        else
        {
            cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity, CartId = cart.Id });
        }

        cart.TotalPrice = await GetCartTotalPriceAsync(userId);
        await _context.SaveChangesAsync();
    }

    public async Task ClearCartAsync(string userId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        if (cart == null) return;
        _context.CartItems.RemoveRange(cart.CartItems);
        cart.TotalPrice = 0;
        await _context.SaveChangesAsync();
    }

    public async Task<Cart?> GetCartByUserIdAsync(string userId)
    {
        return await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);
    }

    public async Task<decimal> GetCartTotalPriceAsync(string userId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        if (cart == null) return 0;

        return cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity);
    }

    public async Task RemoveFromCartAsync(string userId, int productId)
    {
        var cart = await GetCartByUserIdAsync(userId);
        if (cart == null) return;

        var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        if (cartItem != null)
        {
            cart.CartItems.Remove(cartItem);
            cart.TotalPrice = await GetCartTotalPriceAsync(userId);
            await _context.SaveChangesAsync();
        }
    }
}