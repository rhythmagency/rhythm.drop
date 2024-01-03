namespace Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;

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
    protected override async Task RenderNullOrInvalidAsync(TagHelperContext context, TagHelperOutput output)
    {
        await Task.Run(output.SuppressOutput);
    }
}