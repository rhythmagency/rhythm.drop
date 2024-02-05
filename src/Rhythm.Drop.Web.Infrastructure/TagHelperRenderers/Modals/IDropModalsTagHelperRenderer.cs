namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

/// <summary>
/// A contract for rendering a <see cref="DropModalsTagHelperRendererContext"/> when used in a <see cref="TagHelper"/>.
/// </summary>
/// <remarks>This contract exists for dependency injection purposes. Check out the abstract implementations for a more guided implementation.</remarks>
public interface IDropModalsTagHelperRenderer : ITagHelperRenderer<DropModalsTagHelperRendererContext>, ITagHelperRenderer<DropModalTagHelperRendererContext>
{
}
