using Microsoft.Identity.Client;

namespace ECommerceAPI.ViewModels;

public class RefreshRequestDto
{
    public string UserId { get; set; }
    public String Email { get; set; }
    public string RefreshToken { get; set; }
}