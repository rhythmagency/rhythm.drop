namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;

using Microsoft.AspNetCore.Mvc.Rendering;
using Rhythm.Drop.Models.Modals;
using System.Collections.Generic;

/// <summary>
/// The context required to render a <see cref="IDropModalsTagHelperRenderer"/>
/// </summary>
/// <param name="Modals">The modals.</param>
/// <param name="Theme">The theme.</param>
/// <param name="TagName">The optional tag name.</param>
/// <param name="ViewContext">The view context.</param>
public sealed record DropModalsTagHelperRendererContext(IReadOnlyCollection<IModal> Modals, int Level, string Theme, string? TagName, ViewContext ViewContext)
{
}