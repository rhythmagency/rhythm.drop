namespace Rhythm.Drop.Infrastructure;

using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// A contract for creating a builder to setup Drop.
/// </summary>
public interface IRhythmDropBuilder
{
    /// <summary>
    /// Gets the service collection.
    /// </summary>
    IServiceCollection Services { get; }
}