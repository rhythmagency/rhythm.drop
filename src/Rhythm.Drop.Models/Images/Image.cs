namespace Rhythm.Drop.Models.Images;

/// <summary>
/// An implementation of <see cref="IImage"/>.
/// </summary>
/// <param name="Url">The URL.</param>
/// <param name="AltText">The alt text.</param>
/// <param name="Width">The width.</param>
/// <param name="Height">The height.</param>
/// <param name="Sources">The sources.</param>
public sealed record Image(string Url, string? AltText, int? Width, int? Height, IReadOnlyCollection<IImageSource> Sources) : IImage
{
    /// <summary>
    /// Constructs an image with just a URL and alt text.
    /// </summary>
    /// <param name="Url">The URL.</param>
    /// <param name="AltText">The alt text.</param>
    public Image(string Url, string? AltText) : this(Url, AltText, default, default)
    {
    }

    /// <summary>
    /// Constructs an image with dimensions but no sources.
    /// </summary>
    /// <param name="Url">The URL.</param>
    /// <param name="AltText">The alt text.</param>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    public Image(string Url, string? AltText, int? Width, int? Height) : this(Url, AltText, Width, Height, Array.Empty<IImageSource>())
    {
    }
}