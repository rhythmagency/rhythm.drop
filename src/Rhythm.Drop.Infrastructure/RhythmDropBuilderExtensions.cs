namespace Rhythm.Drop.Infrastructure;

using Rhythm.Drop.Infrastructure.Factories;

public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Adds the defaults needed by <see cref="IRhythmDropBuilder"/>.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <returns>A <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder AddInfrastructure(this IRhythmDropBuilder builder)
    {
        return builder
            .AddFactories();
    }
} 
