using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DataBase.Models;

public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Pending"; // Pending, Completed, Cancelled

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }