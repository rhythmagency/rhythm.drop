namespace Rhythm.Drop.Web.Factories;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Infrastructure.Factories;
using Rhythm.Drop.Web.Factories.Components;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to factories.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Registers infrastructure factory dependencies for the Rhythm Drop.
    /// </summary>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder AddFactories(this IRhythmDropBuilder builder)
    {
        return builder
            .SetDefaultComponentMetaDataFactory();
    }

    /// <summary>
    /// Sets the default component meta data factory.
    /// </summary>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    /// <returns></returns>
    public static IRhythmDropBuilder SetDefaultComponentMetaDataFactory(this IRhythmDropBuilder builder)
    {
        return builder.SetComponentMetaDataFactory<DefaultComponentMetaDataFactory>();
    }
}