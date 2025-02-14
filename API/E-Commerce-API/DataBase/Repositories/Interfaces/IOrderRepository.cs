using ECommerceAPI.DataBase.Models;

namespace ECommerceAPI.DataBase.Repositories;
    public interface IOrderRepository
    {
        Task<Order> CreateOrderAsync(string userId);
        Task<Order?> GetOrderByIdAsync(int orderId);
        Task<List<Order>> GetOrdersByUserIdAsync(string userId);
    }