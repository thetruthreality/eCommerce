
using ECommerceAPI.ViewModels;

namespace ECommerceAPI.Services;

public static class ServiceRegistration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<ITokenService,TokenService>();
            services.AddScoped<ICartService,CartService>();
            services.AddScoped<IOrderService,OrderService>();
            return services;
    }
}