namespace Rhythm.Drop.Web.Infrastructure.MetaData.Elements;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// An abstract non-generic type for Element Meta Data.
/// </summary>
/// <param name="Index">The index of the element within the current collection of elements.</param>
/// <param name="Total">The total number of elements within the current collection of elements.</param>
/// <param name="Theme">The theme of the element.</param>
/// <param name="Attributes">The additional HTML attributes.</param>
/// <param name="Section">The optional section of where this element is rendered.</param>
/// <remarks>
/// <para>
/// This type exists to make it easier to construct and return a generic Element Meta Data.
/// </para>
/// <para>
/// It should not be used to create other types.
/// </para>
/// </remarks>
public abstract record ElementMetaData(int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : CollectionMetaData(Index, Total, Theme)
{
    /// <summary>
    /// An abstract non-generic type for Element Meta Data.
    /// </summary>
    /// <remarks>This creates a element meta data without a section for backward compatability.</remarks>
    public ElementMetaData(int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Index, Total, Theme, Attributes, default)
    {
    }

    /// <summary>
    /// Gets the element of the meta data.
    /// </summary>
    /// <returns>A <see cref="IElement"/>.</returns>
    public abstract IElement GetElement();
}