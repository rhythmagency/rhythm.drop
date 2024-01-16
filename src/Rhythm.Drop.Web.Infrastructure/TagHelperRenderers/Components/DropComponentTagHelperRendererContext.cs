namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;

/// <summary>
/// The context required to render a <see cref="IDropComponentsTagHelperRenderer"/>
/// </summary>
/// <param name="Component">The component.</param>
/// <param name="Level">The level.</param>
/// <param name="Theme">The theme.</param>
/// <param name="Index">The index of the component.</param>
/// <param name="Total">The total number of the components.</param>
/// <param name="Attributes">The attributes.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this component is rendered.</param>
public sealed record DropComponentTagHelperRendererContext(IComponent? Component, int Level, string Theme, int Index, int Total, IReadOnlyHtmlAttributeCollection Attributes, ViewContext ViewContext, string? Section)
{
}
