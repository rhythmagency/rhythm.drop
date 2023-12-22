namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;

/// <summary>
/// A contract for rendering <see cref="ILink"/> when used in a <see cref="TagHelper"/>.
/// </summary>
/// <remarks>This contract exists for dependency injection purposes. Check out the abstract implementations for a more guided implementation.</remarks>
public interface IDropLinkTagHelperRenderer : ITagHelperRenderer<ILink>
{
}