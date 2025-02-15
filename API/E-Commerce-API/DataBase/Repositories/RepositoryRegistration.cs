
using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.Services;

namespace ECommerceAPI.Repositories;

public static class RepositoryRegistration 
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICartRepository,CartRepository>();
        services.AddScoped<IOrderRepository,OrderRepository>();
        services.AddScoped<ITokenRepository,TokenRepository>();
        return services;
    }
}