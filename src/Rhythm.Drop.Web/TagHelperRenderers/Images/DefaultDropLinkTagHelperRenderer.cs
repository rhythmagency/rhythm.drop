﻿namespace Rhythm.Drop.Web.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using System.Threading.Tasks;

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
                RenderModelAsPicture(image, output);
            }
            else
            {
                RenderModelAsSingleImage(image, output);
            }
        });
    }

    private static void RenderModelAsPicture(IImage image, TagHelperOutput output)
    {
        output.TagName = "picture";
        output.TagMode = TagMode.StartTagAndEndTag;


        foreach (var source in image.Sources)
        {
            var sourceTag = BuildSourceTag(source); 

            output.Content.AppendHtml(sourceTag);
        }


        var imgTag = BuildImgTag(image);
        output.Content.AppendHtml(imgTag);
    }

    private static IHtmlContent BuildImgTag(IImage image)
    {
        var tagBuilder = new TagBuilder("img");
        tagBuilder.Attributes.Add("src", image.Url);
        tagBuilder.Attributes.Add("alt", image.AltText);

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

    private static void RenderModelAsSingleImage(IImage image, TagHelperOutput output)
    {
        output.TagName = "img";
        output.Attributes.SetAttribute("src", image.Url);
        output.Attributes.SetAttribute("alt", image.AltText);

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
}