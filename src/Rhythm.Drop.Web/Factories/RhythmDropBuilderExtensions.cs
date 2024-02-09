namespace Rhythm.Drop.Web.Factories;

using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to factories.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Registers infrastructure factory dependencies for the Rhythm Drop.
    /// </summary>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <returns>Returns the current <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder AddWebFactories(this IRhythmDropBuilder builder)
    {
        return builder
            .SetDefaultComponentMetaDataFactory()
            .SetDefaultSubcomponentMetaDataFactory()
            .SetDefaultModalMetaDataFactory();
    }

    /// <summary>
    /// Sets the default component meta data factory.
    /// </summary>
    /// <returns>Returns the current <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder SetDefaultComponentMetaDataFactory(this IRhythmDropBuilder builder)
    {
        return builder.SetComponentMetaDataFactory<DefaultComponentMetaDataFactory>();
    }

    /// <summary>
    /// Sets the default subcomponent meta data factory.
    /// </summary>
    /// <returns>Returns the current <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder SetDefaultSubcomponentMetaDataFactory(this IRhythmDropBuilder builder)
    {
        return builder.SetSubcomponentMetaDataFactory<DefaultSubcomponentMetaDataFactory>();
    }

    /// <summary>
    /// Sets the default modal meta data factory.
    /// </summary>
    /// <returns>Returns the current <see cref="IRhythmDropBuilder"/>.</returns>
    public static IRhythmDropBuilder SetDefaultModalMetaDataFactory(this IRhythmDropBuilder builder)
    {
        return builder.SetModalMetaDataFactory<DefaultModalMetaDataFactory>();
    }
}