namespace Rhythm.Drop.Web.ViewComponents;

using Microsoft.AspNetCore.Mvc;
using Rhythm.Drop.Web.TagHelpers;

/// <summary>
/// A view component used by <see cref="DropComponentsTagHelper"/>. This should not be used directly.
/// </summary>
[ViewComponent]
public sealed class RenderComponentViewComponent : ViewComponent
{
    /// <inheritdoc/>
    public IViewComponentResult Invoke(RenderComponentViewComponentInput input)
    {
        return View(input.ViewPath, input.Model);
    }
}