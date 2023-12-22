namespace Rhythm.Drop.Models.Images.SourceSets;

/// <summary>
/// A <see cref="IImageSourceSet"/> which contains a single URL.
/// </summary>
/// <param name="url">The URL.</param>
public sealed class SingleImageSourceSet(string url) : ImageSourceSetBase(new[] { new ImageSourceSetItem(url) })
{
}