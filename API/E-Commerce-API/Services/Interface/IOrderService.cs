using ECommerceAPI.ViewModels;

namespace ECommerceAPI.Services;

    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(string userId);
        Task<OrderDto> GetOrderByIdAsync(int orderId);
        Task<List<OrderDto>> GetOrdersByUserIdAsync(string userId);
    }