namespace Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for creating a item for a <see cref="IImageSourceSet"/>.
/// </summary>
public interface IImageSourceSetItem
{
    /// <summary>
    /// Gets the URL.
    /// </summary>
    string Url { get; }

    /// <summary>
    /// Gets the Descriptor.
    /// </summary>
    /// <remarks>This could be a pixel density (e.g. x1, x2) or other supported value.</remarks>
    string? Descriptor { get; }

    /// <summary>
    /// Attempts to convert the source set item to a string value suitable for markup.
    /// </summary>
    /// <returns>A <see cref="string"/> if the input is valid.</returns>
    string? ToMarkupString();
}