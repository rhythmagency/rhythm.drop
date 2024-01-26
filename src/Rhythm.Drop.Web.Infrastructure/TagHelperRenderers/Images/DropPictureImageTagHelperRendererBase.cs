namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using System.Threading.Tasks;

/// <summary>
/// A base implementation for rendering a <see cref="IImage"/> when used in a <see cref="TagHelper"/> as an img HTML tag within a picture HTML tag.
/// </summary>
public abstract class DropPictureImageTagHelperRendererBase : TagHelperRendererBase<DropImageTagHelperRendererContext>, IDropPictureImageTagHelperRenderer
{
    /// <inheritdoc/>
    protected override Task RenderModelAsync(DropImageTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        if (model.Image is null)
        {
            output.SuppressOutput();
            return Task.CompletedTask;
        }

        var image = model.Image;

        output.TagName = "img";
        output.TagMode = TagMode.SelfClosing;

        SetTagAttributes(image, model.LoadingMode, context, output);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Sets the attributes of the tag helper output.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="loadingMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    protected virtual void SetTagAttributes(IImage model, LoadingMode loadingMode, TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute("src", model.Url);
        output.Attributes.SetAttribute("alt", model.AltText);

        if (loadingMode is LoadingMode.Lazy)
        {
            output.Attributes.SetAttribute("loading", "lazy");
        }

        if (model.Width > 0)
        {
            output.Attributes.SetAttribute("width", model.Width);
        }

        if (model.Height > 0)
        {
            output.Attributes.SetAttribute("height", model.Height);
        }
    }
}