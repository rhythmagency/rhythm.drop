namespace Rhythm.Drop.Builders.Images.Common;

using Rhythm.Drop.Models.Images;

/// <summary>
/// An implementation of <see cref="IUrlAndAltTextImageBuilder"/>.
/// </summary>
/// <param name="altText">The alt text.</param>
/// <param name="url">The URL.</param>
internal sealed class UrlAndAltTextImageBuilder(string? altText, string? url) : IUrlAndAltTextImageBuilder
{
    private readonly List<IImageSource> _sources = new();

    /// <inheritdoc/>
    public string? Url => url;

    /// <inheritdoc/>
    public string? AltText => altText;

    /// <inheritdoc/>
    public IReadOnlyCollection<IImageSource> Sources => _sources.ToArray();

    /// <inheritdoc/>
    public IUrlAndAltTextWithDimensionsImageBuilder AddDimensions(int width, int height)
    {
        return new UrlAndAltTextWithDimensionsImageBuilder(Url, AltText, width, height, Sources);
    }

    /// <inheritdoc/>
    public IUrlAndAltTextImageBuilder AddSource(IImageSource source)
    {
        _sources.Add(source);
        return this;
    }

    /// <inheritdoc/>
    public IUrlAndAltTextImageBuilder AddSources(IReadOnlyCollection<IImageSource> sources)
    {
        _sources.AddRange(sources);
        return this;
    }

    /// <inheritdoc/>
    public IImage? Build()
    {
        if (string.IsNullOrWhiteSpace(Url))
        {
            return default;
        }

        return new Image(Url, AltText, default, default, Sources);
    }
}