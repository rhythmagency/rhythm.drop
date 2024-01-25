namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    /// Renders a <see cref="IImage"/> and <see cref="TagHelperOutput"/> as a picture HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="output">The output.</param>
    protected static void RenderModelAsPicture(IImage image, RenderMode renderMode, TagHelperOutput output)
    {
        output.TagName = "picture";
        output.TagMode = TagMode.StartTagAndEndTag;

        foreach (var source in image.Sources)
        {
            var sourceTag = BuildSourceTag(source); 

            output.Content.AppendHtml(sourceTag);
        }

        var imgTag = BuildImgTag(image, renderMode);
        output.Content.AppendHtml(imgTag);
    }

    /// <summary>
    /// Renders a <see cref="IImage"/> and <see cref="TagHelperOutput"/> as a single img HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    protected virtual void RenderModelAsSingleImage(IImage image, RenderMode renderMode, TagHelperContext context, TagHelperOutput output)
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

    private static IHtmlContent BuildImgTag(IImage image, RenderMode renderMode)
    {
        var tagBuilder = new TagBuilder("img");
        tagBuilder.Attributes.Add("src", image.Url);
        tagBuilder.Attributes.Add("alt", image.AltText);

        if (renderMode is RenderMode.Lazy)
        {
            tagBuilder.Attributes.Add("loading", "lazy");
        }

        if (image.Width > 0)
        {
            tagBuilder.Attributes.Add("width", image.Width.ToString());
        }

        if (image.Height > 0)
        {
            tagBuilder.Attributes.Add("height", image.Height.ToString());
        }

        return tagBuilder.RenderSelfClosingTag();
    }

    private static IHtmlContent BuildSourceTag(IImageSource source)
    {
        var tagBuilder = new TagBuilder("source");

        tagBuilder.Attributes.Add("srcset", source.SourceSet.ToMarkupString());

        if (source.MediaQuery is not null)
        {
            tagBuilder.Attributes.Add("media", source.MediaQuery.ToMarkupString());
        }

        if (string.IsNullOrEmpty(source.MimeType) is false)
        {
            tagBuilder.Attributes.Add("type", source.MimeType);
        }

        if (source.Width > 0)
        {
            tagBuilder.Attributes.Add("width", source.Width.ToString());
        }

        if (source.Height > 0)
        {
            tagBuilder.Attributes.Add("height", source.Height.ToString());
        }

        return tagBuilder.RenderSelfClosingTag();
    }
}