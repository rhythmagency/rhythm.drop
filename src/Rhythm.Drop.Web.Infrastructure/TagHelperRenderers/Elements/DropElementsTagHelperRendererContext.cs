namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Elements;

/// <summary>
/// The context required to render a <see cref="IDropElementsTagHelperRenderer"/>
/// </summary>
/// <param name="Elements">The elements.</param>
/// <param name="Theme">The theme.</param>
/// <param name="TagName">The optional tag name.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this element is rendered.</param>
public sealed record DropElementsTagHelperRendererContext(IReadOnlyCollection<IElement> Elements, string Theme, string? TagName, ViewContext ViewContext, string? Section)
{
}