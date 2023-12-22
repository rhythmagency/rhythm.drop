namespace Rhythm.Drop.Models.Links;

using Rhythm.Drop.Models.Modals;

/// <summary>
/// A contract for creating a link with modal content.
/// </summary>
public interface IModalLink : ILink
{
    /// <summary>
    /// Gets the modal.
    /// </summary>
    IModal Modal { get; }
}