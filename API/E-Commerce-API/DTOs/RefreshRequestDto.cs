using Microsoft.Identity.Client;

namespace ECommerceAPI.DTOs;

public class RefreshRequestDto
{
    public string UserId { get; set; }
    public String Email { get; set; }
    public string RefreshToken { get; set; }
}