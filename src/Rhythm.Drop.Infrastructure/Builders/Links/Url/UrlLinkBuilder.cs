namespace Rhythm.Drop.Infrastructure.Builders.Links.Url;

/// <summary>
/// An implementation of <see cref="IUrlLinkBuilder"/>.
/// </summary>
/// <param name="url">The URL.</param>
internal sealed class UrlLinkBuilder(string? url) : IUrlLinkBuilder
{
    /// <inheritdoc/>
    public string? Url => url;

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder AndLabel(string? label)
    {
        return new UrlAndLabelLinkBuilder(Url, label);
    }
}