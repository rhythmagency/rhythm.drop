namespace Rhythm.Drop.Infrastructure.Builders.Images.Common;

using Rhythm.Drop.Models.Images;

/// <summary>
/// An image builder with a URL and Alt Text.
/// </summary>
public interface IUrlAndAltTextImageBuilder
{
    /// <summary>
    /// Gets the URL of the builder.
    /// </summary>
    public string? Url { get; }

    /// <summary>
    /// Gets the alt text of the builder.
    /// </summary>
    public string? AltText { get; }

    /// <summary>
    /// Gets the sources of the builder.
    /// </summary>
    public IReadOnlyCollection<IImageSource> Sources { get; }

    /// <summary>
    /// Adds a source to the builder.
    /// </summary>
    /// <param name="source">The source.</param>
    /// <returns></returns>
    IUrlAndAltTextImageBuilder AddSource(IImageSource source);

    /// <summary>
    /// Adds multiple sources to the builder.
    /// </summary>
    /// <param name="sources">The sources.</param>
    /// <returns></returns>
    IUrlAndAltTextImageBuilder AddSources(IReadOnlyCollection<IImageSource> sources);

    /// <summary>
    /// Adds dimensions to the builder.
    /// </summary>
    /// <param name="width">The width.</param>
    /// <param name="height">The height.</param>
    /// <returns>A <see cref="IUrlAndAltTextWithDimensionsImageBuilder"/>.</returns>
    IUrlAndAltTextWithDimensionsImageBuilder AddDimensions(int width, int height);

    /// <summary>
    /// Attempts to build a <see cref="IImage"/> if the input is valid.
    /// </summary>
    /// <returns>A <see cref="IImage"/> if the input is valid.</returns>
    IImage? Build();
}