namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using System.Threading.Tasks;

/// <summary>
/// A tag helper that renders a <see cref="IImage"/>.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
[HtmlTargetElement("drop-image", TagStructure = TagStructure.WithoutEndTag)]
public sealed class DropImageTagHelper(IDropImageTagHelperRenderer tagHelperRenderer) : TagHelper
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropImageTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// Gets or sets the <see cref="IImage"/> model.
    /// </summary>
    [HtmlAttributeName("model")]
    public IImage? Model { get; set; }

    /// <summary>
    /// Gets or sets the render mode for this tag helper.
    /// </summary>
    [HtmlAttributeName("render-mode")]
    public RenderMode RenderMode { get; set; } = RenderMode.Default;

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var rendererContext = new DropImageTagHelperRendererContext(Model, RenderMode);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}