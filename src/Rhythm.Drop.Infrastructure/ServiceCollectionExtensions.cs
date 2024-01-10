namespace Rhythm.Drop.Infrastructure;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

/// <summary>
/// A collection of extension methods that augment <see cref="IServiceCollection"/>.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Rhythm Drop with no default settings to the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <param name="configure">The configuration action.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    /// <remarks>Developer must add any dependencies (e.g. Infrastructure and Web) here.</remarks>
    public static IServiceCollection AddRhythmDrop(this IServiceCollection services, Action<IRhythmDropBuilder> configure)
    {
        var builder = new RhythmDropBuilder(services);
        configure(builder);
        return services;
    }

    internal static IServiceCollection Replace<TService, TImplementation>(this IServiceCollection services, ServiceLifetime lifetime) where TImplementation : class, TService
    {
        var serviceType = typeof(TService);
        var implementationType = typeof(TImplementation);

        return services.Replace(ServiceDescriptor.Describe(serviceType, implementationType, lifetime));
    }
}