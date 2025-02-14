
using ECommerceAPI.DataBase.Repositories;
using ECommerceAPI.Services;

namespace ECommerceAPI.Repositories;

public static class RepositoryRegistration 
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        // Register services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProductRepository, ProductRepository>();
        return services;
    }
}