namespace Rhythm.Drop.Infrastructure.Builders.Links;

using Rhythm.Drop.Infrastructure.Builders.Links.Common;
using Rhythm.Drop.Infrastructure.Builders.Links.Modals;
using Rhythm.Drop.Infrastructure.Builders.Links.Url;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// The default implementation of <see cref="ILinkBuilder"/>.
/// </summary>
public sealed class DefaultLinkBuilder : ILinkBuilder
{
    /// <inheritdoc/>
    public ILabelLinkBuilder WithLabel(string? label)
    {
        return new LabelLinkBuilder(label);
    }

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