namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

/// <summary>
/// A contract for rendering a <see cref="DropComponentsTagHelperRendererContext"/> when used in a <see cref="TagHelper"/>.
/// </summary>
/// <remarks>This contract exists for dependency injection purposes. Check out the abstract implementations for a more guided implementation.</remarks>
public interface IDropComponentsTagHelperRenderer : ITagHelperRenderer<DropComponentsTagHelperRendererContext>, ITagHelperRenderer<DropComponentTagHelperRendererContext>
{
}
