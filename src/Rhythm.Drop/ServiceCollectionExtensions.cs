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
    /// <remarks>For a more controlled installation use <see cref="Infrastructure.ServiceCollectionExtensions.AddRhythmDrop(IServiceCollection, Action{IRhythmDropBuilder})"/>.</remarks>
    public static IServiceCollection AddRhythmDrop(this IServiceCollection services)
    {
        return services.AddRhythmDrop((builder) =>
        {
            builder
            .AddInfrastructure()
            .AddWeb();
        });
    }
}