namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Subcomponents;

/// <summary>
/// The context required to render a <see cref="IDropSubcomponentsTagHelperRenderer"/>
/// </summary>
/// <param name="Subcomponent">The subcomponent.</param>
/// <param name="Theme">The theme.</param>
/// <param name="Index">The index of the subcomponent.</param>
/// <param name="Total">The total number of the subcomponents.</param>
/// <param name="Attributes">The attributes.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this subcomponent is rendered.</param>
public sealed record DropSubcomponentTagHelperRendererContext(ISubcomponent? Subcomponent, string Theme, int Index, int Total, IReadOnlyHtmlAttributeCollection Attributes, ViewContext ViewContext, string? Section)
{
}
