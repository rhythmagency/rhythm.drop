namespace Rhythm.Drop.Web.MetaData.Elements;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Elements;
using Rhythm.Drop.Web.Infrastructure.MetaData.Elements;

/// <summary>
/// A generic type for Element Meta Data.
/// </summary>
/// <typeparam name="TElement">The type of the element.</typeparam>
/// <param name="Element">The element.</param>
/// <param name="Index">The index of the element within the current collection of elements.</param>
/// <param name="Total">The total number of elements within the current collection of elements.</param>
/// <param name="Theme">The theme of the element.</param>
/// <param name="Attributes">The attributes to be passed to the element.</param>
/// <param name="Section">The optional section of where this element is rendered.</param>
public sealed record ElementMetaData<TElement>(TElement Element, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section) : ElementMetaData(Index, Total, Theme, Attributes, Section) where TElement : IElement
{
    /// <summary>
    /// A generic type for Element Meta Data
    /// </summary>
    /// <remarks>This creates a element meta data without a section for backward compatability.</remarks>
    public ElementMetaData(TElement Element, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : this(Element, Index, Total, Theme, Attributes, default)
    {
    }

    /// <inheritdoc/>
    public override IElement GetElement()
    {
        return Element;
    }
}