namespace Rhythm.Drop.Web.Infrastructure.Factories;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to factories.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Sets the <see cref="IComponentMetaDataFactory"/>.
    /// </summary>
    /// <typeparam name="TFactory">The type of the new factory.</typeparam>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetComponentMetaDataFactory<TFactory>(this IRhythmDropBuilder builder) where TFactory : class, IComponentMetaDataFactory
    {
        builder.Services.Replace<IComponentMetaDataFactory, TFactory>(ServiceLifetime.Singleton);
        return builder;
    }

    /// <summary>
    /// Sets the <see cref="ISubcomponentMetaDataFactory"/>.
    /// </summary>
    /// <typeparam name="TFactory">The type of the new factory.</typeparam>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetSubcomponentMetaDataFactory<TFactory>(this IRhythmDropBuilder builder) where TFactory : class, ISubcomponentMetaDataFactory
    {
        builder.Services.Replace<ISubcomponentMetaDataFactory, TFactory>(ServiceLifetime.Singleton);
        return builder;
    }

    /// <summary>
    /// Sets the <see cref="IModalMetaDataFactory"/>.
    /// </summary>
    /// <typeparam name="TFactory">The type of the new factory.</typeparam>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetModalMetaDataFactory<TFactory>(this IRhythmDropBuilder builder) where TFactory : class, IModalMetaDataFactory
    {
        builder.Services.Replace<IModalMetaDataFactory, TFactory>(ServiceLifetime.Singleton);
        return builder;
    }
}