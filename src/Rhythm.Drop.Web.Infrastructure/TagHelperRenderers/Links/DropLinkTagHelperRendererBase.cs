namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Models.Links;
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
        output.TagName = GetTagName(model);
        output.TagMode = TagMode.StartTagAndEndTag;

        SetTagAttributes(output, model);

        await SetInnerContent(output, model);
    }

    /// <summary>
    /// Sets the attributes of the tag helper output.
    /// </summary>
    /// <param name="output">The output.</param>
    /// <param name="model">The model.</param>
    protected virtual void SetTagAttributes(TagHelperOutput output, ILink model)
    {
        if (model is IModalLink modalLink)
        {
            output.Attributes.SetAttribute(ModalLinkUniqueKeyAttributeName, modalLink.Modal.UniqueKey);
        }

        foreach (var attribute in model.Attributes)
        {
            if (ShouldSetAttribute(attribute, model, output) is false)
            {
                continue;
            }

            output.Attributes.SetAttribute(attribute.Name, attribute.Value);
        }
    }

    /// <summary>
    /// Determines where to set an attribute or not.
    /// </summary>
    /// <param name="attribute">The current attribute.</param>
    /// <param name="model">The model.</param>
    /// <param name="output">The output.</param>
    /// <returns>A <see cref="bool"/>.</returns>
    /// <remarks>This exists so developers have an extension point to control the output of attributes.</remarks>
    protected virtual bool ShouldSetAttribute(IHtmlAttribute attribute, ILink model, TagHelperOutput output)
    {
        return true;
    }

    /// <summary>
    /// Sets the inner content of the tag helper output.
    /// </summary>
    /// <param name="output">The output.</param>
    /// <param name="model">The model.</param>
    /// <returns></returns>
    protected virtual async Task SetInnerContent(TagHelperOutput output, ILink model)
    {
        var childContent = await output.GetChildContentAsync();
        if (childContent.IsEmptyOrWhiteSpace)
        {
            output.Content.SetHtmlContent(model.Label);
        }
    }

    /// <inheritdoc/>
    protected override async Task RenderNullOrInvalidAsync(TagHelperContext context, TagHelperOutput output)
    {
        await output.SupressOutputOrTag();
    }

    /// <summary>
    /// Gets the tag name for the current link.
    /// </summary>
    /// <param name="model">The model.</param>
    /// <returns>A <see cref="string"/> which represents the HTML tag.</returns>
    protected virtual string GetTagName(ILink model)
    {
        return model switch
        {
            IModalLink => "button",
            ILink => "a"
        };
    }
}