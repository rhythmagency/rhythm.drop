namespace Rhythm.Drop.Infrastructure.Factories;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Infrastructure;
using Rhythm.Drop.Infrastructure.Factories.Components;
using Rhythm.Drop.Infrastructure.Factories.Images;
using Rhythm.Drop.Infrastructure.Factories.Links;

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
            .SetDefaultImageBuilderFactory()
            .SetDefaultLinkBuilderFactory()
            .SetDefaultComponentMetaDataFactory();
    }

    /// <summary>
    /// Sets the default component meta data factory.
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static IRhythmDropBuilder SetDefaultComponentMetaDataFactory(this IRhythmDropBuilder builder)
    {
        builder.SetComponentMetaDataFactory<DefaultComponentMetaDataFactory>();
        return builder;
    }

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
    /// Sets the default link builder factory.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultLinkBuilderFactory(this IRhythmDropBuilder builder)
    {
        return builder.SetLinkBuilderFactory<DefaultLinkBuilderFactory>();
    }

    /// <summary>
    /// Sets the link builder factory.
    /// </summary>
    /// <typeparam name="TLinkBuilderFactory">The type of the new link builder factory.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetLinkBuilderFactory<TLinkBuilderFactory>(this IRhythmDropBuilder builder) where TLinkBuilderFactory : class, ILinkBuilderFactory
    {
        builder.Services.Replace<ILinkBuilderFactory, TLinkBuilderFactory>(ServiceLifetime.Singleton);
        return builder;
    }

    /// <summary>
    /// Sets the default image builder factory.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultImageBuilderFactory(this IRhythmDropBuilder builder)
    {
        return builder.SetImageBuilderFactory<DefaultImageBuilderFactory>();
    }

    /// <summary>
    /// Sets the image builder factory.
    /// </summary>
    /// <typeparam name="TImageBuilderFactory">The type of the new image builder factory.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetImageBuilderFactory<TImageBuilderFactory>(this IRhythmDropBuilder builder) where TImageBuilderFactory : class, IImageBuilderFactory
    {
        builder.Services.Replace<IImageBuilderFactory, TImageBuilderFactory>(ServiceLifetime.Singleton);

        return builder;
    }

}