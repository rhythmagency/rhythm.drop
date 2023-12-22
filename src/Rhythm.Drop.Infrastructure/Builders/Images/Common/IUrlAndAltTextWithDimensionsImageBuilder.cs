namespace Rhythm.Drop.Infrastructure.Builders.Images.Common;

using Rhythm.Drop.Models.Images;

/// <summary>
/// A image builder with a URL, alt text and dimensions.
/// </summary>
public interface IUrlAndAltTextWithDimensionsImageBuilder
{
    /// <summary>
    /// Gets the URL of the builder.
    /// </summary>
    string? Url { get; }

    /// <summary>
    /// Gets the Alt Text of the builder.
    /// </summary>
    string? AltText { get; }

    /// <summary>
    /// Gets the width of the builder.
    /// </summary>
    int? Width { get; }

    /// <summary>
    /// Gets the height of the builder.
    /// </summary>
    int? Height { get; }

    /// <summary>
    /// Gets the sources of the builder.
    /// </summary>
    IReadOnlyCollection<IImageSource> Sources { get; }

    /// <summary>
    /// Adds a source to the builder.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>A <see cref="IUrlAndAltTextWithDimensionsImageBuilder"/>.</returns>
    IUrlAndAltTextWithDimensionsImageBuilder AddSource(IImageSource source);

    /// <summary>
    /// Adds multiple sources to the builder.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns>A <see cref="IUrlAndAltTextWithDimensionsImageBuilder"/>.</returns>
    IUrlAndAltTextWithDimensionsImageBuilder AddSources(IReadOnlyCollection<IImageSource> sources);

    /// <summary>
    /// Attempts to build an <see cref="IImage"/> if the current input is valid.
    /// </summary>
    /// <returns>A <see cref="IImage"/> if the input is valid.</returns>
    IImage? Build();
}