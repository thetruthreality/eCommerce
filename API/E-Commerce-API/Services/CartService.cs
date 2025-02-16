using AutoMapper;
using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.DTOs;
using ECommerceAPI.Services;

namespace ECommerceAPI.Services;

public class CartService : ICartService
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;
    public CartService(ICartRepository cartRepository,
    IMapper mapper
    )
    {
         _cartRepository = cartRepository;
         _mapper = mapper;
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
        var reurndate=_mapper.Map<CartDto>(cart);
            return reurndate;
    }

    public async Task RemoveFromCartAsync(string userId, int productId,int? quantity)
    {
       await _cartRepository.RemoveFromCartAsync(userId, productId,quantity);
    }
}