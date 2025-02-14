using Microsoft.AspNetCore.Identity;

namespace ECommerceAPI.DataBase.Models;

public class ApplicationUser : IdentityUser
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}