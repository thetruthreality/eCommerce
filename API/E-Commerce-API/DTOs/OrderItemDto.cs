using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs;

public class OrderItemDto
{
[Required]
        public int OrderId { get; set; }



        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }
}