
using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.ViewModels;
public class OrderDto
{
    public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal OrderAmount { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Completed, Cancelled

        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
}