namespace Rhythm.Drop.Builders.Links.Modals;

using Rhythm.Drop.Models.Modals;

/// <summary>
/// An implementation of <see cref="IModalLinkBuilder"/>.
/// </summary>
/// <param name="modal">The modal.</param>
internal sealed class ModalLinkBuilder(IModal modal) : IModalLinkBuilder
{
    /// <inheritdoc/>
    public IModal Modal => modal;

    /// <inheritdoc/>
    public IModalAndLabelLinkBuilder AndLabel(string? label)
    {
        return new ModalAndLabelLinkBuilder(Modal, label);
    }
}