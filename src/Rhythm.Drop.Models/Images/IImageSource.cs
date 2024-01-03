namespace Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for implementing an image source.
/// </summary>
public interface IImageSource
{
    /// <summary>
    /// Gets the source set.
    /// </summary>
    IReadOnlyImageSourceSet SourceSet { get; }

    /// <summary>
    /// Gets the optional mime type.
    /// </summary>
    string? MimeType { get; }

    /// <summary>
    /// Gets the optional media query.
    /// </summary>
    IImageSourceMediaQuery? MediaQuery { get; }

    /// <summary>
    /// Gets the optional width.
    /// </summary>
    int? Width { get; }

    /// <summary>
    /// Gets the optional height.
    /// </summary>
    int? Height { get; }
}