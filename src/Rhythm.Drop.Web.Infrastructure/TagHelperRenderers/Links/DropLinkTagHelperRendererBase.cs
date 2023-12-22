namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers;
using System.Threading.Tasks;

/// <summary>
/// A base class for rendering <see cref="ILink"/> when used in a <see cref="TagHelper"/>.
/// </summary>
public abstract class DropLinkTagHelperRendererBase : TagHelperRendererBase<ILink>, IDropLinkTagHelperRenderer
{
    /// <inheritdoc/>
    protected override async Task RenderNullAsync(TagHelperContext context, TagHelperOutput output)
    {
        await output.SupressOutputOrTag();
    }
}