using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceAPI.DataBase.Models;

public class CartItem
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; }

    [Required]
    public int Quantity { get; set; } = 1;

    [Required]
    public int CartId { get; set; }

    [ForeignKey("CartId")]
    public Cart Cart { get; set; }
}