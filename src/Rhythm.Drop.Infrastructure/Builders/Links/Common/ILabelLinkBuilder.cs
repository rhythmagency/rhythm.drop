namespace Rhythm.Drop.Infrastructure.Builders.Links.Common;

using Rhythm.Drop.Infrastructure.Builders.Links.Modals;
using Rhythm.Drop.Infrastructure.Builders.Links.Url;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a <see cref="ILinkBuilder"/> with a label.
/// </summary>
public interface ILabelLinkBuilder
{
    /// <summary>
    /// Gets the label.
    /// </summary>
    string? Label { get; }

    /// <summary>
    /// Adds a URL to the builder.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>A <see cref="IUrlAndLabelLinkBuilder"/>.</returns>
    IUrlAndLabelLinkBuilder AndUrl(string? url);

    /// <summary>
    /// Adds content to the builder.
    /// </summary>
    /// <param name="modal">The modal.</param>
    /// <returns>A <see cref="IModalWithLabelLinkBuilder"/>.</returns>
    IModalAndLabelLinkBuilder AndModal(IModal modal);
}