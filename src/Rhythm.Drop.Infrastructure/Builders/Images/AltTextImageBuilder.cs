namespace Rhythm.Drop.Infrastructure.Builders.Images;

using Rhythm.Drop.Infrastructure.Builders.Images.Common;

/// <summary>
/// An implementation of <see cref="IAltTextImageBuilder"/>.
/// </summary>
/// <param name="altText">The alt text.</param>
public sealed class AltTextImageBuilder(string? altText) : IAltTextImageBuilder
{
    /// <inheritdoc/>
    public string? AltText => altText;

    /// <inheritdoc/>
    public IUrlAndAltTextImageBuilder AndUrl(string? url)
    {
        return new UrlAndAltTextImageBuilder(AltText, url);
    }
}