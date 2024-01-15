namespace Rhythm.Drop.Builders.Images.Common;

using Rhythm.Drop.Models.Images;

/// <summary>
/// An implementation of <see cref="IUrlAndAltTextWithDimensionsImageBuilder"/>
/// </summary>
/// <param name="url">The URL.</param>
/// <param name="altText">The alt text.</param>
/// <param name="width">The width.</param>
/// <param name="height">The height.</param>
/// <param name="sources">The sources.</param>
internal sealed class UrlAndAltTextWithDimensionsImageBuilder(string? url, string? altText, int? width, int? height, IReadOnlyCollection<IImageSource> sources) : IUrlAndAltTextWithDimensionsImageBuilder
{
    private readonly List<IImageSource> _sources = new(sources);

    /// <inheritdoc/>
    public string? Url => url;

    /// <inheritdoc/>
    public string? AltText => altText;

    /// <inheritdoc/>
    public int? Width => width;

    /// <inheritdoc/>
    public int? Height => height;

    /// <inheritdoc/>
    public IReadOnlyCollection<IImageSource> Sources => _sources.ToArray();

    /// <inheritdoc/>
    public IUrlAndAltTextWithDimensionsImageBuilder AddSource(IImageSource source)
    {
        _sources.Add(source);

        return this;
    }

    /// <inheritdoc/>
    public IUrlAndAltTextWithDimensionsImageBuilder AddSources(IReadOnlyCollection<IImageSource> sources)
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

        return new Image(Url, AltText, Width, Height, Sources);
    }
}