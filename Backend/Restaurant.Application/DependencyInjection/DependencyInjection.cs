using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using Restaurant.Application.Services;
using Restaurant.Application.Interfaces;
using Restaurant.Application.Interfaces.Persistence;

namespace Restaurant.Application.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IRestaurantService, RestaurantService>();
        
        return services;
    }
}
