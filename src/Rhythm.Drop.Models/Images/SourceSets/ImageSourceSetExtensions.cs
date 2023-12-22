namespace Rhythm.Drop.Models.Images.SourceSets;

/// <summary>
/// A collection of extension methods that augment the <see cref="ImageSourceSet"/> class.
/// </summary>
public static class ImageSourceSetExtensions
{
    /// <summary>
    /// Adds a <see cref="IImageSourceSetItem"/> with only a URL.
    /// </summary>
    /// <param name="sourceSet">The current <see cref="ImageSourceSet"/>.</param>
    /// <param name="url">The URL.</param>
    public static void Add(this ImageSourceSet sourceSet, string url)
    {
        sourceSet.Add(new ImageSourceSetItem(url));
    }

    /// <summary>
    /// Adds a <see cref="IImageSourceSetItem"/> with a URL and a descriptor.
    /// </summary>
    /// <param name="sourceSet">The current <see cref="ImageSourceSet"/>.</param>
    /// <param name="url">The URL.</param>
    /// <param name="descriptor">The descriptor.</param>
    public static void Add(this ImageSourceSet sourceSet, string url, string descriptor)
    {
        sourceSet.Add(new ImageSourceSetItem(url, descriptor));
    }
}