namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// The context required to render a <see cref="IDropSubcomponentsTagHelperRenderer"/>
/// </summary>
/// <param name="Subcomponents">The subcomponents.</param>
/// <param name="Theme">The theme.</param>
/// <param name="TagName">The optional tag name.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this subcomponent is rendered.</param>
public sealed record DropSubcomponentsTagHelperRendererContext(IReadOnlyCollection<ISubcomponent> Subcomponents, string Theme, string? TagName, ViewContext ViewContext, string? Section)
{
}