namespace Rhythm.Drop.Infrastructure.Builders.Links.Modals;

using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a link with a modal.
/// </summary>
public interface IModalLinkBuilder
{
    /// <summary>
    /// Gets the modal.
    /// </summary>
    IModal Modal { get; }

    /// <summary>
    /// Adds a label to the builder.
    /// </summary>
    /// <param name="label">The label.</param>
    /// <returns>A <see cref="IModalAndLabelLinkBuilder"/>.</returns>
    IModalAndLabelLinkBuilder AndLabel(string? label);
}