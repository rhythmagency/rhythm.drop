namespace Rhythm.Drop.Web.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using System.Threading.Tasks;
using RenderMode = Rhythm.Drop.Web.Infrastructure.RenderMode;

/// <summary>
/// The default implementation of <see cref="IDropImageTagHelperRenderer"/>.
/// </summary>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropImageTagHelperRenderer : DropImageTagHelperRendererBase
{
    /// <inheritdoc/>
    protected override async Task RenderModelAsync(DropImageTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        if (model.Image is null)
        {
            output.SuppressOutput();
            return;
        }

        await Task.Run(() =>
        {
            var image = model.Image;

            if (image.Sources.Count > 0)
            {
                RenderModelAsPicture(image, model.RenderMode, output);
            }
            else
            {
                RenderModelAsSingleImage(image, model.RenderMode, context, output);
            }
        });
    }
}