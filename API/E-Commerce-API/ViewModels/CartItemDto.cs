
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.ViewModels;

public class CartItemDto
{
     public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int Quantity { get; set; } = 1;

    public string ProductName { get; set; }

    public decimal Price { get; set; }

    public decimal TotalPrice => Price * Quantity;
}