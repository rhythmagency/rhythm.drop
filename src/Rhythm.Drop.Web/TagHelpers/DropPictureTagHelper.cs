namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using System.Threading.Tasks;

/// <summary>
/// A picture tag that renders a <see cref="IImage"/>.
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
[HtmlTargetElement(PictureTagName, Attributes = DropModelAttributeName, TagStructure = TagStructure.NormalOrSelfClosing)]
[RestrictChildren(ImgTagName)]
public sealed class DropPictureTagHelper(IDropPictureTagHelperRenderer tagHelperRenderer) : DropImageTagHelperBase
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropPictureTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <summary>
    /// Gets or sets the image.
    /// </summary>
    [HtmlAttributeName(DropModelAttributeName)]
    public IImage? Model { get; set; }

    /// <summary>
    /// Gets or sets the render mode.
    /// </summary>
    [HtmlAttributeName(LoadingModeAttributeName)]
    public LoadingMode RenderMode { get; set; } = LoadingMode.Default;

    /// <inheritdoc/>
    public override void Init(TagHelperContext context)
    {
        if (Model is not null)
        {
            // set the context items to be used by any child tags.
            context.Items[DropModelContextItemName] = Model;
            context.Items[DropLoadingModeContextItemName] = RenderMode;
        }
    }

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        var renderContext = new DropImageTagHelperRendererContext(Model, RenderMode);

        await _tagHelperRenderer.RenderAsync(renderContext, context, output);
    }
}