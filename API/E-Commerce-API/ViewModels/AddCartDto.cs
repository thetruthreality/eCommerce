namespace ECommerceAPI.ViewModels;

public class AddCartDto
{
    public string UserId{ get; set; }
    public int ProductId{ get; set; }

    public int Quantity{ get; set; }
}