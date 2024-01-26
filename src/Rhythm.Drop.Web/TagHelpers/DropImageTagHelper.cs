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
[HtmlTargetElement(ImgTagName, Attributes = DropModelAttributeName, TagStructure = TagStructure.WithoutEndTag)]
public sealed class DropImageTagHelper(IDropImageTagHelperRenderer tagHelperRenderer) : DropImageTagHelperBase
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropImageTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// Gets or sets the <see cref="IImage"/> model.
    /// </summary>
    [HtmlAttributeName(DropModelAttributeName)]
    public IImage? Model { get; set; }

    /// <summary>
    /// Gets or sets the loading mode for this tag helper.
    /// </summary>
    [HtmlAttributeName(LoadingModeAttributeName)]
    public LoadingMode LoadingMode { get; set; } = LoadingMode.Default;

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var rendererContext = new DropImageTagHelperRendererContext(Model, LoadingMode);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    /// <inheritdoc/>
    public override int Order => DropTagHelperOrdering.Default;
}