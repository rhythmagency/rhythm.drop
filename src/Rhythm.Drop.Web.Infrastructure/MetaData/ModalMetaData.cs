namespace Rhythm.Drop.Web.Infrastructure.MetaData;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// An abstract non-generic type for Modal Meta Data.
/// </summary>
/// <param name="Theme">The theme of the modal.</param>
/// <param name="Attributes">The additional HTML attributes.</param>
/// <param name="Section">The optional section of where this modal is rendered.</param>
/// <remarks>
/// <para>
/// This type exists to make it easier to construct and return a generic Modal Meta Data.
/// </para>
/// <para>
/// It should not be used to create other types.
/// </para>
/// </remarks>
public abstract record ModalMetaData(string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : MetaData(Theme)
{
    /// <summary>
    /// An abstract non-generic type for Modal Meta Data.
    /// </summary>
    /// <remarks>This creates a modal meta data without a section for backward compatability.</remarks>
    public ModalMetaData(string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Theme, Attributes, default)
    {
    }

    /// <summary>
    /// Gets the modal of the meta data.
    /// </summary>
    /// <returns>A <see cref="IModal"/>.</returns>
    public abstract IModal GetModal();
}