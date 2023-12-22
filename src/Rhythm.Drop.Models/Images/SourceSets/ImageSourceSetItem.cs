namespace Rhythm.Drop.Models.Images.SourceSets;

/// <summary>
/// An implementation of <see cref="IImageSourceSetItem"/>.
/// </summary>
/// <param name="Url">The URL.</param>
/// <param name="Descriptor">The descriptor.</param>
public sealed record ImageSourceSetItem(string Url, string? Descriptor) : IImageSourceSetItem
{
    /// <summary>
    /// Constructs a <see cref="ImageSourceSetItem"/> which only has a URL.
    /// </summary>
    /// <param name="Url"></param>
    public ImageSourceSetItem(string Url) : this(Url, default) { }

    /// <inheritdoc/>
    public string ToMarkupString()
    {
        if (string.IsNullOrWhiteSpace(Descriptor))
        {
            return Url;
        }

        return $"{Url} {Descriptor}";
    }
}