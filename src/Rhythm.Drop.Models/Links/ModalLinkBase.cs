namespace Rhythm.Drop.Models.Links;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A base implementation to be used by other modal links.
/// </summary>
/// <param name="TagName">The tag name</param>
/// <param name="Modal">The modal.</param>
/// <param name="Label">The label.</param>
/// <param name="Attributes">The attribute collection.</param>
public abstract record ModalLinkBase(string TagName, IModal Modal, string Label, IReadOnlyHtmlAttributeCollection Attributes) : IModalLink
{
}