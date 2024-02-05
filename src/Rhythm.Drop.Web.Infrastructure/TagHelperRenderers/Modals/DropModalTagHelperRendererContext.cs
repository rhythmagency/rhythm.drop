namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;

/// <summary>
/// The context required to render a <see cref="IDropModalsTagHelperRenderer"/>
/// </summary>
/// <param name="Modal">The modal.</param>
/// <param name="Theme">The theme.</param>
/// <param name="Attributes">The attributes.</param>
/// <param name="ViewContext">The view context</param>
/// <param name="Section">The optional section of where this modal is rendered.</param>
public sealed record DropModalTagHelperRendererContext(IModal? Modal, string Theme, IReadOnlyHtmlAttributeCollection Attributes, ViewContext ViewContext, string? Section)
{
}
