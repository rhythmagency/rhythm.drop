namespace Rhythm.Drop.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// A collection of extension methods that augment <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    internal static IServiceCollection Replace<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime) where TImplementation : class, TService
    {
        var serviceType = typeof(TService);
        var implementationType = typeof(TImplementation);

        return services.Replace(ServiceDescriptor.Describe(serviceType, implementationType, lifetime));
    }
}