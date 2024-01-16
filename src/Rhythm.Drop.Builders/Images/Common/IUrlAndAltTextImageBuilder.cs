namespace Rhythm.Drop.Builders.Images.Common;

using Rhythm.Drop.Models.Images;

/// <summary>
/// An image builder with a URL and Alt Text.
/// </summary>
public interface IUrlAndAltTextImageBuilder : IAddImageSourcesImageBuilder<IUrlAndAltTextImageBuilder>, IAddDimensionsImageBuilder<IUrlAndAltTextWithDimensionsImageBuilder>
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
    /// Attempts to build a <see cref="IImage"/> if the input is valid.
    /// </summary>
    /// <returns>A <see cref="IImage"/> if the input is valid.</returns>
    IImage? Build();
}