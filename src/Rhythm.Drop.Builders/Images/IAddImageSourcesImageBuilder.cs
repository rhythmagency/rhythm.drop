namespace Rhythm.Drop.Builders.Images;

using Rhythm.Drop.Models.Images;
using System.Collections.Generic;

/// <summary>
/// A contract for creating an image builder that can add <see cref="IImageSource"/> objects.
/// </summary>
/// <typeparam name="TBuilder">The type of the builder to return after adding <see cref="IImageSource"/> objects.</typeparam>
public interface IAddImageSourcesImageBuilder<TBuilder>
{
    /// <summary>
    /// Adds a source to the builder.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder AddSource(IImageSource source);

    /// <summary>
    /// Adds multiple sources to the builder.
    /// </summary>
    /// <param name="sources">The sources.</param>
    /// <returns>A <typeparamref name="TBuilder"/>.</returns>
    TBuilder AddSources(IReadOnlyCollection<IImageSource> sources);
}