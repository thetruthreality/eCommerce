using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.ViewModels;

public class CartDto
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }  // Stores the user ID

    public ICollection<CartItemDto> CartItems { get; set; } = new List<CartItemDto>();

    public decimal TotalPrice { get; set; } = 0;
}