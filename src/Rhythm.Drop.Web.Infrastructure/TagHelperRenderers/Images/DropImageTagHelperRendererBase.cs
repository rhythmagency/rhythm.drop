namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering <see cref="IImage"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropImageTagHelperRendererBase : TagHelperRendererBase<DropImageTagHelperRendererContext>, IDropImageTagHelperRenderer
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

            if (ShouldRenderOutputAsPicture(image, context, output))
            {
                RenderOutputAsPicture(image, model.LoadingMode, context, output);
            }
            else
            {
                RenderOutputAsImg(image, model.LoadingMode, context, output);
            }
        });
    }

    /// <summary>
    /// Determines whether the output should be rendered as a picture HTML tag or a single img HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns><para>A <see cref="bool"/>. If <see langword="true" /> the output should be rendered a picture HTML tag. Otherwise it should be rendered a single img HTML tag.</para>
    /// </returns>
    protected virtual bool ShouldRenderOutputAsPicture(IImage image, TagHelperContext context, TagHelperOutput output)
    {
        return image.Sources.Count > 0;
    }

    /// <summary>
    /// Renders a <see cref="IImage"/> and <see cref="TagHelperOutput"/> as a picture HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual void RenderOutputAsPicture(IImage image, LoadingMode renderMode, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "picture";
        output.TagMode = TagMode.StartTagAndEndTag;

        foreach (var source in image.Sources)
        {
            var sourceHtml = BuildImageSourceHtmlContent(source, renderMode, context, output); 

            output.Content.AppendHtml(sourceHtml);
        }

        var imgHtml = BuildImgHtmlContent(image, renderMode, context, output);
        output.Content.AppendHtml(imgHtml);
    }

    /// <summary>
    /// Renders a <see cref="IImage"/> and <see cref="TagHelperOutput"/> as a single img HTML tag.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the img tag when no picture tag is present.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual void RenderOutputAsImg(IImage image, LoadingMode renderMode, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "img";
        output.Attributes.SetAttribute("src", image.Url);
        output.Attributes.SetAttribute("alt", image.AltText);

        if (renderMode is LoadingMode.Lazy)
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
    /// Creates a <see cref="TagBuilder"/> used by <see cref="BuildImgHtmlContent(IImage, LoadingMode, TagHelperContext, TagHelperOutput)"/>.
    /// </summary>
    /// <param name="image">The image.</param>
    /// <param name="renderMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="TagBuilder"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the img tag used by a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual TagBuilder CreateImgTagBuilder(IImage image, LoadingMode renderMode, TagHelperContext context, TagHelperOutput output)
    {
        var tagBuilder = new TagBuilder("img");
        tagBuilder.Attributes.Add("src", image.Url);
        tagBuilder.Attributes.Add("alt", image.AltText);

        if (renderMode is LoadingMode.Lazy)
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
    /// Creates a <see cref="TagBuilder"/> used by <see cref="BuildImageSourceHtmlContent(IImageSource, LoadingMode, TagHelperContext, TagHelperOutput)"/>.
    /// </summary>
    /// <param name="source">The image source.</param>
    /// <param name="renderMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="TagBuilder"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual TagBuilder CreateImageSourceTagBuilder(IImageSource source, LoadingMode renderMode, TagHelperContext context, TagHelperOutput output)
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
    /// <param name="renderMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="IHtmlContent"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This should only bn replaced entirely if you do not intend to use the output from <see cref="CreateImgTagBuilder(IImage, LoadingMode, TagHelperContext, TagHelperOutput)"/>.</para>
    /// </remarks>
    protected IHtmlContent BuildImgHtmlContent(IImage image, LoadingMode renderMode, TagHelperContext context, TagHelperOutput output)
    {
        var tagBuilder = CreateImgTagBuilder(image, renderMode, context, output);

        return tagBuilder.RenderSelfClosingTag();
    }

    /// <summary>
    /// Builds the <see cref="IHtmlContent"/> required by a source HTML tag when rendered within an picture HTML tag.
    /// </summary>
    /// <param name="source">The image source.</param>
    /// <param name="renderMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="IHtmlContent"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This should only bn replaced entirely if you do not intend to use the output from <see cref="CreateImageSourceTagBuilder(IImageSource, LoadingMode, TagHelperContext, TagHelperOutput)"/>.</para>
    /// </remarks>
    protected IHtmlContent BuildImageSourceHtmlContent(IImageSource source, LoadingMode renderMode, TagHelperContext context, TagHelperOutput output)
    {
        var tagBuilder = CreateImageSourceTagBuilder(source, renderMode, context, output);

        return tagBuilder.RenderSelfClosingTag();
    }

    /// <inheritdoc/>
    protected override async Task RenderNullOrInvalidAsync(TagHelperContext context, TagHelperOutput output)
    {
        await Task.Run(output.SuppressOutput);
    }
}