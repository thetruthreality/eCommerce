using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DataBase.Models;

public class Cart
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }  // Stores the user ID

    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public decimal TotalPrice { get; set; } = 0;
}