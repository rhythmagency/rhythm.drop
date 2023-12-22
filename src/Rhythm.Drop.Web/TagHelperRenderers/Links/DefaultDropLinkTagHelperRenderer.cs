namespace Rhythm.Drop.Web.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Web.Infrastructure.Helpers.Modals;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropLinkTagHelperRenderer"/>.
/// </summary>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropLinkTagHelperRenderer : DropLinkTagHelperRendererBase
{
    private readonly IModalPersistenceHelper _modalPersistenceHelper;

    public DefaultDropLinkTagHelperRenderer(IModalPersistenceHelper modalPersistenceHelper)
    {
        _modalPersistenceHelper = modalPersistenceHelper;
    }

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

            output.TagName = link.TagName;
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(link.Label);

            foreach (var attribute in link.Attributes)
            {
                output.Attributes.SetAttribute(attribute.Name, attribute.Value);
            }
        });
    }
}