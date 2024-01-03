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
    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with an existing source set.
    /// </summary>
    /// <param name="SourceSet">The source set.</param>
    public ImageSource(IReadOnlyImageSourceSet SourceSet) : this(SourceSet, default, default, default, default)
    {
    }

    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with an existing source set and media query.
    /// </summary>
    /// <param name="SourceSet">The source set.</param>
    /// <param name="MediaQuery">The media query.</param>
    public ImageSource(IReadOnlyImageSourceSet SourceSet, IImageSourceMediaQuery MediaQuery) : this(SourceSet, MediaQuery, default, default, default)
    {
    }

    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with an existing source set, media query and dimensions.
    /// </summary>
    /// <param name="SourceSet">The source set.</param>
    /// <param name="MediaQuery">The media query.</param>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    public ImageSource(IReadOnlyImageSourceSet SourceSet, IImageSourceMediaQuery MediaQuery, int Width, int Height) : this(SourceSet, MediaQuery, Width, Height, default)
    {
    }

    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with single URL.
    /// </summary>
    /// <param name="Url">The url.</param>
    public ImageSource(string Url) : this(Url, default, default, default, default)
    {
    }

    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with single URL and media query.
    /// </summary>
    /// <param name="Url">The URL.</param>
    /// <param name="MediaQuery">The media query.</param>
    public ImageSource(string Url, IImageSourceMediaQuery MediaQuery) : this(Url, MediaQuery, default, default, default)
    {
    }

    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with an existing source set, media query and dimensions.
    /// </summary>
    /// <param name="Url">The URL.</param>
    /// <param name="MediaQuery">The media query.</param>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    public ImageSource(string Url, IImageSourceMediaQuery? MediaQuery, int Width, int Height) : this(Url, MediaQuery, Width, Height, default)
    {
    }

    /// <summary>
    /// Constructs a <see cref="ImageSource"/> with an existing source set, media query, dimensions and MIME Type.
    /// </summary>
    /// <param name="Url">The URL.</param>
    /// <param name="MediaQuery">The media query.</param>
    /// <param name="Width">The width.</param>
    /// <param name="Height">The height.</param>
    /// <param name="MimeType">The MIME type.</param>
    public ImageSource(string Url, IImageSourceMediaQuery? MediaQuery, int? Width, int? Height, string? MimeType) : this(new SingleImageSourceSet(Url).ToReadOnly(), MediaQuery, Width, Height, MimeType)
    {
    }
}