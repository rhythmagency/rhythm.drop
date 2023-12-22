namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Links;
using System.Threading.Tasks;

/// <summary>
/// A tag helper that renders a <see cref="ILink"/>.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
[HtmlTargetElement("drop-link", TagStructure = TagStructure.NormalOrSelfClosing)]
public sealed class DropLinkTagHelper(IDropLinkTagHelperRenderer tagHelperRenderer) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropLinkTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// Gets or sets the <see cref="ILink"/> model.
    /// </summary>
    [HtmlAttributeName("model")]
    public ILink? Model { get; set; }

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        await _tagHelperRenderer.RenderAsync(Model, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}