namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering <see cref="ILink"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropLinkTagHelperRendererBase : TagHelperRendererBase<ILink>, IDropLinkTagHelperRenderer
{
    /// <summary>
    /// Gets the attribute name used for setting the <see cref="IModal.UniqueKey"/> value to rendered <see cref="IModalLink"/>.
    /// </summary>
    protected virtual string ModalLinkUniqueKeyAttributeName => "data-modal-target";

    /// <inheritdoc/>
    protected override async Task RenderModelAsync(ILink model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = GetTagName(model, context);
        output.TagMode = TagMode.StartTagAndEndTag;

        if (model is IModalLink modalLink)
        {
            SetModalLinkOutputModifications(modalLink, context, output);
        }

        SetTagAttributes(model, context, output);

        await SetInnerContentAsync(model, context, output);
    }

    /// <summary>
    /// Sets the attributes of the tag helper output.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    protected virtual void SetTagAttributes(ILink model, TagHelperContext context, TagHelperOutput output)
    {
        foreach (var attribute in model.Attributes)
        {
            if (ShouldSetAttribute(attribute, model, context, output) is false)
            {
                continue;
            }

            output.Attributes.SetAttribute(attribute.Name, attribute.Value);
        }
    }

    /// <summary>
    /// Sets the output modifications needs for a <see cref="IModalLink"/>.
    /// </summary>
    /// <param name="modalLink">The modal link.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    protected virtual void SetModalLinkOutputModifications(IModalLink modalLink, TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.SetAttribute(ModalLinkUniqueKeyAttributeName, modalLink.Modal.UniqueKey);
    }

    /// <summary>
    /// Determines where to set an attribute or not.
    /// </summary>
    /// <param name="attribute">The current attribute.</param>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    /// <remarks>This exists so developers have an extension point to control the output of attributes.</remarks>
    protected virtual bool ShouldSetAttribute(IHtmlAttribute attribute, ILink model, TagHelperContext context, TagHelperOutput output)
    {
        return true;
    }

    /// <summary>
    /// Sets the inner content of the tag helper output.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <param name="output">The output.</param>
    /// <returns></returns>
    protected virtual async Task SetInnerContentAsync(ILink model, TagHelperContext context, TagHelperOutput output)
    {
        var childContent = await output.GetChildContentAsync();
        if (childContent.IsEmptyOrWhiteSpace)
        {
            output.Content.SetHtmlContent(model.Label);
        }
    }

    /// <inheritdoc/>
    protected override Task RenderNullOrInvalidAsync(TagHelperContext context, TagHelperOutput output)
    {
        // use SupressOutputOrTag instead of SuppressOutput as tag may have child content.
        return Task.Run(output.SupressOutputOrTag);
    }

    /// <summary>
    /// Gets the tag name for the current link.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <param name="context">The context.</param>
    /// <returns>A <see cref="string"/> which represents the HTML tag.</returns>
    protected virtual string GetTagName(ILink model, TagHelperContext context)
    {
        return model switch
        {
            IModalLink => "button",
            ILink => "a"
        };
    }
}