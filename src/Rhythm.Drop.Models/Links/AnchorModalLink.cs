namespace Rhythm.Drop.Models.Links;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A modal link that is rendered as an anchor tag.
/// </summary>
/// <param name="modal">The modal.</param>
/// <param name="Label">The label.</param>
/// <param name="Attributes">The attribute collection.</param>
public sealed record AnchorModalLink(IModal modal, string Label, IReadOnlyHtmlAttributeCollection Attributes) : ModalLinkBase("a", modal, Label, Attributes)
{
}