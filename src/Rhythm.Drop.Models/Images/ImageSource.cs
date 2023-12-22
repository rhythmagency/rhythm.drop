namespace Rhythm.Drop.Models.Images;

using Rhythm.Drop.Models.Images.SourceSets;

/// <summary>
/// An image source.
/// </summary>
/// <param name="SourceSet">The source set.</param>
/// <param name="MediaQuery">The media query.</param>
/// <param name="Width">The width.</param>
/// <param name="Height">The height.</param>
/// <param name="MimeType">The MIME type.</param>
public sealed record ImageSource(IReadOnlyImageSourceSet SourceSet, IImageSourceMediaQuery? MediaQuery, int? Width, int? Height, string? MimeType) : IImageSource
{
    public ImageSource(IReadOnlyImageSourceSet SourceSet) : this(SourceSet, default, default, default, default)
    {
    }

    public ImageSource(IReadOnlyImageSourceSet SourceSet, IImageSourceMediaQuery MediaQuery) : this(SourceSet, MediaQuery, default, default, default)
    {
    }

    public ImageSource(IReadOnlyImageSourceSet SourceSet, IImageSourceMediaQuery MediaQuery, int Width, int Height) : this(SourceSet, MediaQuery, Width, Height, default)
    {
    }

    public ImageSource(string url) : this(url, default, default, default, default)
    {
    }

    public ImageSource(string url, IImageSourceMediaQuery MediaQuery) : this(url, MediaQuery, default, default, default)
    {
    }

    public ImageSource(string url, IImageSourceMediaQuery? MediaQuery, int Width, int Height) : this(url, MediaQuery, Width, Height, default)
    {
    }

    public ImageSource(string url, IImageSourceMediaQuery? MediaQuery, int? Width, int? Height, string? MimeType) : this(new SingleImageSourceSet(url).ToReadOnly(), MediaQuery, Width, Height, MimeType)
    {
    }
}