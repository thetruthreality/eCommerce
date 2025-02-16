using System.ComponentModel.DataAnnotations;

namespace ECommerceAPI.DTOs;

 public class RegisterViewModel
 {
    [Required]
     public string Email { get; set; }
     [Required]
     public string Password { get; set; }
 }