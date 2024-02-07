namespace Rhythm.Drop.Web.Infrastructure.Factories.MetaData;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// The input required by <see cref="IModalMetaDataFactory"/>.
/// </summary>
/// <param name="Modal">The modal.</param>
/// <param name="Theme">The theme of the modal.</param>
/// <param name="Attributes">The attributes to be passed to the modal.</param>
/// <param name="Section">The optional section of where this modal is rendered.</param>
public sealed record ModalMetaDataFactoryInput(IModal Modal, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section)
{
}