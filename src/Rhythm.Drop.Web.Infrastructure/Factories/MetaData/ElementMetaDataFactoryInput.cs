namespace Rhythm.Drop.Web.Infrastructure.Factories.MetaData;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// The input required by <see cref="IElementMetaDataFactory"/>.
/// </summary>
/// <param name="Element">The element.</param>
/// <param name="Index">The index of the element within the current collection of elements.</param>
/// <param name="Total">The total number of elements within the current collection of elements.</param>
/// <param name="Theme">The theme of the element.</param>
/// <param name="Attributes">The attributes to be passed to the element.</param>
/// <param name="Section">The optional section of where this element is rendered.</param>
public sealed record ElementMetaDataFactoryInput(IElement Element, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes, string? Section)
{
}