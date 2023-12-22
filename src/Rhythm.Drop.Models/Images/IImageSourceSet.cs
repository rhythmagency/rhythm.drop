namespace Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for creating a source set for a <see cref="IImageSource"/>.
/// </summary>
public interface IImageSourceSet : IReadOnlyCollection<IImageSourceSetItem>
{
    /// <summary>
    /// Attempts to convert the image source set to a string value suitable for markup.
    /// </summary>
    /// <returns>A <see cref="string"/> if the input is valid.</returns>
    string? ToMarkupString();
}