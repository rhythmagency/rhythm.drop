namespace Rhythm.Drop.Builders;

using Microsoft.Extensions.DependencyInjection;
using Rhythm.Drop.Builders.Images;
using Rhythm.Drop.Builders.Links;
using Rhythm.Drop.Infrastructure;

/// <summary>
/// A collection of extension methods for <see cref="IRhythmDropBuilder"/> related to builders.
/// </summary>
public static class RhythmDropBuilderExtensions
{
    /// <summary>
    /// Registers builder dependencies for the Rhythm Drop.
    /// </summary>
    /// <param name="builder">The current <see cref="IRhythmDropBuilder"/>.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder AddBuilders(this IRhythmDropBuilder builder)
    {
        return builder
            .SetDefaultImageBuilder()
            .SetDefaultLinkBuilder();
    }

    /// <summary>
    /// Sets the default link builder.
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultLinkBuilder(this IRhythmDropBuilder builder)
    {
        return builder.SetLinkBuilder<DefaultLinkBuilder>();
    }

    /// <summary>
    /// Sets the link builder.
    /// </summary>
    /// <typeparam name="TLinkBuilder">The type of the new link builder.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetLinkBuilder<TLinkBuilder>(this IRhythmDropBuilder builder) where TLinkBuilder : class, ILinkBuilder
    {
        builder.Services.Replace<ILinkBuilder, TLinkBuilder>(ServiceLifetime.Transient);
        return builder;
    }

    /// <summary>
    /// Sets the default image builder .
    /// </summary>
    /// <param name="builder">The current builder.</param>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetDefaultImageBuilder(this IRhythmDropBuilder builder)
    {
        return builder.SetImageBuilder<DefaultImageBuilder>();
    }

    /// <summary>
    /// Sets the image builder .
    /// </summary>
    /// <typeparam name="TImageBuilder">The type of the new image builder.</typeparam>
    /// <remarks>Returns the current <see cref="IRhythmDropBuilder"/>.</remarks>
    public static IRhythmDropBuilder SetImageBuilder<TImageBuilder>(this IRhythmDropBuilder builder) where TImageBuilder : class, IImageBuilder
    {
        builder.Services.Replace<IImageBuilder, TImageBuilder>(ServiceLifetime.Transient);

        return builder;
    }
}