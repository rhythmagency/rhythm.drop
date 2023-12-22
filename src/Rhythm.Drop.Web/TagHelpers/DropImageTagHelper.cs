namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using System.Threading.Tasks;

/// <summary>
/// A tag helper that renders a <see cref="IImage"/>.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
[HtmlTargetElement("drop-image", TagStructure = TagStructure.NormalOrSelfClosing)]
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

    [HtmlAttributeName("render-mode")]
    public ImageRenderMode RenderMode { get; set; } = ImageRenderMode.Default;

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var rendererContext = new DropImageTagHelperRendererContext(Model, RenderMode);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}