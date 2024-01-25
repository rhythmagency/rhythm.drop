namespace Rhythm.Drop.Web.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

/// <summary>
/// The default implementation of <see cref="IDropImageTagHelperRenderer"/>.
/// </summary>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropImageTagHelperRenderer : DropImageTagHelperRendererBase
{
    /// <inheritdoc/>
    protected override bool ShouldRenderOutputAsPicture(IImage image, TagHelperContext context, TagHelperOutput output)
    {
        return image.Sources.Count > 0;
    }
}