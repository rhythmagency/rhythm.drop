namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for rendering a <see cref="IImage"/> when used in a <see cref="TagHelper"/> as an img HTML tag within a picture HTML tag.
/// </summary>
/// <remarks>This contract exists for dependency injection purposes. Check out the abstract implementations for a more guided implementation.</remarks>
public interface IDropPictureImageTagHelperRenderer : ITagHelperRenderer<DropImageTagHelperRendererContext>
{
}