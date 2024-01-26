namespace Rhythm.Drop;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;

/// <summary>
/// An implementation of <see cref="IRhythmDropBuilder"/>.
/// </summary>
/// <param name="services">
/// The services.
/// </param>
public sealed class RhythmDropBuilder(IServiceCollection services) : IRhythmDropBuilder
{
    /// <inheritdoc/>
    public IServiceCollection Services => services;
}