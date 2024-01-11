namespace Rhythm.Drop;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web;

/// <summary>
/// A collection of extension methods that augment implementations of <see cref="IServiceCollection"/> regarding Rhythm Drop.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Rhythm Drop with default dependencies to the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    /// <remarks>For custom functionality use <see cref="AddRhythmDrop(IServiceCollection, Action{IRhythmDropBuilder})"/>.</remarks>
    public static IServiceCollection AddRhythmDrop(this IServiceCollection services)
    {
        return services.AddRhythmDrop((builder) => {});
    }

    /// <summary>
    /// Adds Rhythm Drop with default settings the current <see cref="IServiceCollection"/> plus additional overrides.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <param name="configure">The configuration action.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    /// <remarks>Default settings (e.g. Infrastructure and Web) are add the first time this method is called.</remarks>
    public static IServiceCollection AddRhythmDrop(this IServiceCollection services, Action<IRhythmDropBuilder> configure)
    {
        var builder = new RhythmDropBuilder(services);
     
        if (services.HasRhythmDropDefaultsAddedMarker() is false)
        {
            builder
            .AddInfrastructure()
            .AddWeb();

            services.AddRhythmDropDefaultsAddedMarker();
        }       
        
        configure(builder);
        return services;
    }

    /// <summary>
    /// Checks if the <see cref="RhythmDropDefaultsAddedMarker"/> exists in the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <returns>A <see cref="bool"/> which represents whether it was found or not.</returns>
    private static bool HasRhythmDropDefaultsAddedMarker(this IServiceCollection services)
    {
        return services.Any(x => x.ServiceType == typeof(RhythmDropDefaultsAddedMarker));
    }

    /// <summary>
    /// Adds the <see cref="RhythmDropDefaultsAddedMarker"/> to the current <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The current services.</param>
    /// <returns>A <see cref="IServiceCollection"/>.</returns>
    private static IServiceCollection AddRhythmDropDefaultsAddedMarker(this IServiceCollection services)
    {
        services.AddSingleton<RhythmDropDefaultsAddedMarker>();
        return services;
    }
}