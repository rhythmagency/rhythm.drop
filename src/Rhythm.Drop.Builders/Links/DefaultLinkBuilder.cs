namespace Rhythm.Drop.Builders.Links;

using Rhythm.Drop.Builders.Links.Modals;
using Rhythm.Drop.Builders.Links.Url;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// The default implementation of <see cref="ILinkBuilder"/>.
/// </summary>
public sealed class DefaultLinkBuilder : ILinkBuilder
{
    /// <inheritdoc/>
    public IModalLinkBuilder WithModal(IModal modal)
    {
        return new ModalLinkBuilder(modal);
    }

    /// <inheritdoc/>
    public IUrlLinkBuilder WithUrl(string? url)
    {
        return new UrlLinkBuilder(url);
    }
}