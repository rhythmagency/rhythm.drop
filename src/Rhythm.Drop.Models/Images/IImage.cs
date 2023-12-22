namespace Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for creating a image.
/// </summary>
public interface IImage
{
    /// <summary>
    /// Gets the URL.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the alt text.
    /// </summary>
    string? AltText { get; }

    /// <summary>
    /// Gets the width.
    /// </summary>
    public int? Width { get; }

    /// <summary>
    /// Gets the height.
    /// </summary>
    public int? Height { get; }

    /// <summary>
    /// Gets the sources.
    /// </summary>
    public IReadOnlyCollection<IImageSource> Sources { get; }
}