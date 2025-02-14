using ECommerceAPI.ViewModels;

namespace ECommerceAPI.Services;

public interface ICheckoutService
{
    Task<CheckoutPreviewDto> GetCheckoutPreviewAsync(string userId);
}