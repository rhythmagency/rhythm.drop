namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Rhythm.Drop.Models.Images;

public sealed record DropImageTagHelperRendererContext(IImage? Image, ImageRenderMode RenderMode)
{
}