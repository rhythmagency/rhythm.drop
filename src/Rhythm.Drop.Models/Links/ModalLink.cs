namespace Rhythm.Drop.Models.Links;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// An implementation of <see cref="IModalLink"/>.
/// </summary>
/// <param name="Modal">The modal.</param>
/// <param name="Label">The label.</param>
/// <param name="Attributes">The attribute collection.</param>
public sealed record ModalLink(IModal Modal, string Label, IReadOnlyHtmlAttributeCollection Attributes) : IModalLink
{
}