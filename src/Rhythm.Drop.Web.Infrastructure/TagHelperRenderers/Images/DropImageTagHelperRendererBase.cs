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
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual void RenderOutputAsPicture(IImage image, RenderMode renderMode, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "picture";
        output.TagMode = TagMode.StartTagAndEndTag;

        foreach (var source in image.Sources)
        {
            var sourceHtml = BuildImageSourceHtmlContent(source, renderMode, context); 

            output.Content.AppendHtml(sourceHtml);
        }

        var imgHtml = BuildImgHtmlContent(image, renderMode, context);
        output.Content.AppendHtml(imgHtml);
    }

    /// <summary>
    /// Renders a <see cref="IImage"/> and <see cref="TagHelperOutput"/> as a single img HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the img tag when no picture tag is present.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual void RenderOutputAsImg(IImage image, RenderMode renderMode, TagHelperContext context, TagHelperOutput output)
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

    /// <summary>
    /// Creates a <see cref="TagBuilder"/> used by <see cref="BuildImgHtmlContent(IImage, RenderMode, TagHelperContext)"/>.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="TagBuilder"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the img tag used by a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual TagBuilder CreateImgTagBuilder(IImage image, RenderMode renderMode, TagHelperContext context)
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

        return tagBuilder;
    }

    /// <summary>
    /// Creates a <see cref="TagBuilder"/> used by <see cref="BuildImageSourceHtmlContent(IImageSource, RenderMode, TagHelperContext)"/>.
    /// </summary>
    /// <param name="source">The image source.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="TagBuilder"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual TagBuilder CreateImageSourceTagBuilder(IImageSource source, RenderMode renderMode, TagHelperContext context)
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

        return tagBuilder;
    }

    /// <summary>
    /// Builds the <see cref="IHtmlContent"/> required by a img HTML tag when rendered within an picture HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="IHtmlContent"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This should only bn replaced entirely if you do not intend to use the output from <see cref="CreateImgTagBuilder(IImage, RenderMode, TagHelperContext)"/>.</para>
    /// </remarks>
    protected IHtmlContent BuildImgHtmlContent(IImage image, RenderMode renderMode, TagHelperContext context)
    {
        var tagBuilder = CreateImgTagBuilder(image, renderMode, context);

        return tagBuilder.RenderSelfClosingTag();
    }

    /// <summary>
    /// Builds the <see cref="IHtmlContent"/> required by a source HTML tag when rendered within an picture HTML tag.
    /// </summary>
    /// <param name="source">The image source.</param>
    /// <param name="renderMode">The render mode.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="IHtmlContent"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This should only bn replaced entirely if you do not intend to use the output from <see cref="CreateImageSourceTagBuilder(IImageSource, RenderMode, TagHelperContext)"/>.</para>
    /// </remarks>
    protected IHtmlContent BuildImageSourceHtmlContent(IImageSource source, RenderMode renderMode, TagHelperContext context)
    {
        var tagBuilder = CreateImageSourceTagBuilder(source, renderMode, context);

        return tagBuilder.RenderSelfClosingTag();
    }

    /// <inheritdoc/>
    protected override async Task RenderNullOrInvalidAsync(TagHelperContext context, TagHelperOutput output)
    {
        await Task.Run(output.SuppressOutput);
    }
}