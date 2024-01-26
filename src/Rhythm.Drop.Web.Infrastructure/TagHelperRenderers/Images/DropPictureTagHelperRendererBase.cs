namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using System.Threading.Tasks;

/// <summary>
/// A base implementation for rendering a <see cref="IImage"/> when used in a <see cref="TagHelper"/> as a picture HTML tag.
/// </summary>
public abstract class DropPictureTagHelperRendererBase : TagHelperRendererBase<DropImageTagHelperRendererContext>, IDropPictureTagHelperRenderer
{
    /// <inheritdoc/>
    protected override async Task RenderModelAsync(DropImageTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        if (model.Image is null)
        {
            output.SuppressOutput();
            return;
        }

        var image = model.Image;
        var loadingMode = model.LoadingMode;

        output.TagName = "picture";
        output.TagMode = TagMode.StartTagAndEndTag;

        AppendSourcesContent(image, loadingMode, context, output);
        await AppendImageContentAsync(image, loadingMode, context, output);
    }

    /// <summary>
    /// Appends the <see cref="IImageSource"/> collection to the tag helper output.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="loadingMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    protected virtual void AppendSourcesContent(IImage model, LoadingMode loadingMode, TagHelperContext context, TagHelperOutput output)
    {
        foreach (var source in model.Sources)
        {
            var sourceHtml = BuildImageSourceHtmlContent(source, loadingMode, context, output);
            output.PreContent.AppendHtml(sourceHtml);
        }
    }

    /// <summary>
    /// Appends the image HTML tag to the tag helper output if one doesn't already exist.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="loadingMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="Task"/>.</returns>
    protected virtual async Task AppendImageContentAsync(IImage model, LoadingMode loadingMode, TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync();
        if (childContent.IsEmptyOrWhiteSpace is false)
        {
            return;
        }

        var imgHtml = BuildImgHtmlContent(model, loadingMode, context, output);
        output.Content.AppendHtml(imgHtml);
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
    /// <param name="loadingMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="TagBuilder"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This can be replaced entirely or the base method can be used as a starting point for modifications.</para>
    /// </remarks>
    protected virtual TagBuilder CreateImageSourceTagBuilder(IImageSource source, LoadingMode loadingMode, TagHelperContext context, TagHelperOutput output)
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
    /// <param name="loadingMode">The loading mode.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="IHtmlContent"/>.</returns>
    /// <remarks>
    /// <para>This is intended to be a developer friendly extension point to modify the source tag used by a picture tag.</para>
    /// <para>This should only bn replaced entirely if you do not intend to use the output from <see cref="CreateImageSourceTagBuilder(IImageSource, LoadingMode, TagHelperContext, TagHelperOutput)"/>.</para>
    /// </remarks>
    protected IHtmlContent BuildImageSourceHtmlContent(IImageSource source, LoadingMode loadingMode, TagHelperContext context, TagHelperOutput output)
    {
        var tagBuilder = CreateImageSourceTagBuilder(source, loadingMode, context, output);

        return tagBuilder.RenderSelfClosingTag();
    }
}