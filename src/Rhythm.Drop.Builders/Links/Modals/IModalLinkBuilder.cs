namespace Rhythm.Drop.Builders.Links.Modals;

using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a link with a modal.
/// </summary>
public interface IModalLinkBuilder : IAndLabelLinkBuilder<IModalAndLabelLinkBuilder>
{
    /// <summary>
    /// Gets the modal.
    /// </summary>
    IModal Modal { get; }
}