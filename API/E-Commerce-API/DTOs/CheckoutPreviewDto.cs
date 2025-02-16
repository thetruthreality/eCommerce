namespace ECommerceAPI.DTOs;

public class CheckoutPreviewDto
{
    public List<CartItemDto> CartItems { get; set; }
    public decimal TotalAmount { get; set; }
}
