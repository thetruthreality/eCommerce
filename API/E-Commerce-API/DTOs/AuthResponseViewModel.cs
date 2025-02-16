
namespace ECommerceAPI.DTOs;

public class AuthResponseViewModel
{
   public string? RefreshToken { get; set; }
   public string Token { get; set; } 

   public string UserId{get;set;} 
}