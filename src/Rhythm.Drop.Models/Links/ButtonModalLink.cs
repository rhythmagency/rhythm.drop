namespace Rhythm.Drop.Models.Links;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// A modal link that is rendered as a button tag.
/// </summary>
/// <param name="Modal">The modal.</param>
/// <param name="Label">The label.</param>
/// <param name="Attributes">The attribute collection.</param>
public sealed record ButtonModalLink(IModal Modal, string Label, IReadOnlyHtmlAttributeCollection Attributes) : ModalLinkBase("button", Modal, Label, Attributes)
{
}