
using System.Reflection;
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
         var assembly = Assembly.GetExecutingAssembly();

        // Register Generic Repository
        services.AddScoped(typeof(IRepository<>), typeof(EfCoreRepository<>));
          // Register Generic Repository

        // Automatically register all repository implementations
        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IRepository<>)))
            .AsImplementedInterfaces()
            .WithScopedLifetime());
        return services;
    }
}