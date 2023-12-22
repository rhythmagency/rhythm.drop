namespace Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for creating a media query for an <see cref="IImageSource"/>.
/// </summary>
public interface IImageSourceMediaQuery
{
    /// <summary>
    /// Attempts to convert the media query to a string value suitable for markup.
    /// </summary>
    /// <returns>A <see cref="string"/> if the input is valid.</returns>
    string? ToMarkupString();
}