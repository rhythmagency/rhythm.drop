namespace Rhythm.Drop.Web.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Web.Infrastructure.Helpers.Modals;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropLinkTagHelperRenderer"/>.
/// </summary>
/// <param name="modalPersistenceHelper">The modal persistence helper.</param>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropLinkTagHelperRenderer(IModalPersistenceHelper modalPersistenceHelper) : DropLinkTagHelperRendererBase
{
    /// <summary>
    /// The modal persistence helper.
    /// </summary>
    private readonly IModalPersistenceHelper _modalPersistenceHelper = modalPersistenceHelper;

    /// <inheritdoc/>
    protected override async Task RenderModelAsync(ILink link, TagHelperContext context, TagHelperOutput output)
    {
        await Task.Run(() =>
        {
            if (link is IModalLink modalLink)
            {
                _modalPersistenceHelper.Persist(modalLink);
                output.Attributes.SetAttribute("data-modal-target", modalLink.Modal.UniqueKey);
            }

            output.TagName = GetTagName(link);
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(link.Label);

            foreach (var attribute in link.Attributes)
            {
                output.Attributes.SetAttribute(attribute.Name, attribute.Value);
            }
        });
    }

    private static string GetTagName(ILink link)
    {
        return link switch
        {
            IModalLink => "button",
            ILink => "a"
        };
    }
}