namespace Rhythm.Drop.Infrastructure.Builders.Links.Common;

using Rhythm.Drop.Infrastructure.Builders.Links.Modals;
using Rhythm.Drop.Infrastructure.Builders.Links.Url;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// An implementation of <see cref="ILabelLinkBuilder"/>.
/// </summary>
/// <param name="label">The label.</param>
internal sealed class LabelLinkBuilder(string? label) : ILabelLinkBuilder
{
    /// <inheritdoc/>
    public string? Label => label;

    /// <inheritdoc/>
    public IModalAndLabelLinkBuilder AndModal(IModal modal)
    {
        return new ModalAndLabelLinkBuilder(modal, Label);
    }

    /// <inheritdoc/>
    public IUrlAndLabelLinkBuilder AndUrl(string? url)
    {
        return new UrlAndLabelLinkBuilder(url, Label);
    }
}