
namespace Rhythm.Drop.Web.MetaData.Modals;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure.MetaData.Modals;

/// <summary>
/// A generic type for Modal Meta Data.
/// </summary>
/// <typeparam name="TModal">The type of the modal.</typeparam>
/// <param name="Modal">The modal.</param>
/// <param name="Theme">The theme of the modal.</param>
/// <param name="Attributes">The attributes to be passed to the modal.</param>
/// <param name="Section">The optional section of where this modal is rendered.</param>
public sealed record ModalMetaData<TModal>(TModal Modal, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : ModalMetaData(Theme, Attributes, Section) where TModal : IModal
{
    /// <summary>
    /// A generic type for Modal Meta Data without a section.
    /// </summary>
    public ModalMetaData(TModal Modal, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Modal, Theme, Attributes, default)
    {
    }

    /// <inheritdoc/>
    public override IModal GetModal()
    {
        return Modal;
    }

    /// <summary>
    /// Gets all the attributes from the meta data and the modal.
    /// </summary>
    /// <returns>A <see cref="IReadOnlyHtmlAttributeCollection"/>.</returns>
    public IReadOnlyHtmlAttributeCollection AllAttributes()
    {
        var collection = new HtmlAttributeCollection(Attributes);
        collection.SetAttributes(Modal.Attributes);

        return collection.ToReadOnly();
    }
}