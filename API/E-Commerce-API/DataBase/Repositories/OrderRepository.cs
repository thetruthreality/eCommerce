using ECommerceAPI.Database;
using ECommerceAPI.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.DataBase.Repositories;

public class OrderRepository : IOrderRepository
{
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(string userId)
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null || !cart.CartItems.Any())
                throw new Exception("Cart is empty!");

            var order = new Order
            {
                UserId = userId,
                TotalAmount = cart.CartItems.Sum(ci => ci.Product.Price * ci.Quantity),
                Status = "PaymentDone"
            };
            //after order done ,total price of cart will be zero
            //becuase no item in cart
            cart.TotalPrice=0;

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            foreach (var cartItem in cart.CartItems)
            {
                _context.OrderItems.Add(new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = cartItem.ProductId,
                    Quantity = cartItem.Quantity,
                    Price = cartItem.Product.Price
                });

                // Reduce product stock
                cartItem.Product.StockQuantity -= cartItem.Quantity;
            }

            // Clear the cart after order placement
            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order?> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(string userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }
    }