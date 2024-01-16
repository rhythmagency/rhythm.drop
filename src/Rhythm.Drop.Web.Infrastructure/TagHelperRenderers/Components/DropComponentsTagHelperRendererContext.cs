namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Components;

/// <summary>
/// The context required to render a <see cref="IDropComponentsTagHelperRenderer"/>
/// </summary>
/// <param name="Components">The components.</param>
/// <param name="Level">The level.</param>
/// <param name="Theme">The theme.</param>
/// <param name="TagName">The optional tag name.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this component is rendered.</param>
public sealed record DropComponentsTagHelperRendererContext(IReadOnlyCollection<IComponent> Components, int Level, string Theme, string? TagName, ViewContext ViewContext, string? Section)
{
}