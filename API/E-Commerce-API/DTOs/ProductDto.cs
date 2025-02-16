using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs;

public class ProductDto
{
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public decimal Price { get; set; }

    [Required]
    public int StockQuantity { get; set; }

    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}