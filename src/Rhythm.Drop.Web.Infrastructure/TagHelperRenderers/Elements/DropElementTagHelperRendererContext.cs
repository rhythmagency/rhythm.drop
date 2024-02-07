namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// The context required to render a <see cref="IDropElementsTagHelperRenderer"/>
/// </summary>
/// <param name="Element">The element.</param>
/// <param name="Theme">The theme.</param>
/// <param name="Index">The index of the element.</param>
/// <param name="Total">The total number of the elements.</param>
/// <param name="Attributes">The attributes.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this element is rendered.</param>
public sealed record DropElementTagHelperRendererContext(IElement? Element, string Theme, int Index, int Total, IReadOnlyHtmlAttributeCollection Attributes, ViewContext ViewContext, string? Section)
{
}
