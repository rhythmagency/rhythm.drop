namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;
using System.Threading.Tasks;
using RenderMode = Rhythm.Drop.Web.Infrastructure.RenderMode;

/// <summary>
/// A base class for rendering <see cref="IImage"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropImageTagHelperRendererBase : TagHelperRendererBase<DropImageTagHelperRendererContext>, IDropImageTagHelperRenderer
{
    /// <summary>
    /// Renders a <see cref="IImage"/> and <see cref="TagHelperOutput"/> as a single img HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="output">The output.</param>
    protected virtual void RenderModelAsSingleImage(IImage image, RenderMode renderMode, TagHelperOutput output)
    {
        output.TagName = "img";
        output.Attributes.SetAttribute("src", image.Url);
        output.Attributes.SetAttribute("alt", image.AltText);

        if (renderMode is RenderMode.Lazy)
        {
            output.Attributes.SetAttribute("loading", "lazy");
        }

        if (image.Width > 0)
        {
            output.Attributes.SetAttribute("width", image.Width);
        }

        if (image.Height > 0)
        {
            output.Attributes.SetAttribute("height", image.Height);
        }

        output.TagMode = TagMode.SelfClosing;
    }

    /// <inheritdoc/>
    protected override async Task RenderNullOrInvalidAsync(TagHelperContext context, TagHelperOutput output)
    {
        await Task.Run(output.SuppressOutput);
    }
}