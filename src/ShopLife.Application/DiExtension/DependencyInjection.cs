using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShopLife.Application.DiExtension;

/// <summary>
/// Application DI Extension
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Application DI Extension method
    /// </summary>
    /// <param name="services">ServiceCollection</param>
    /// <returns></returns>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
