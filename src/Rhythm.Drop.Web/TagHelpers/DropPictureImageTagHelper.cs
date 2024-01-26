namespace Rhythm.Drop.Web.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

/// <summary>
/// <para>A tag helper used within a <see cref="DropPictureTagHelper"/>.</para>
/// <para>This tag helper is ignored if not used within a <see cref="DropPictureTagHelper"/> and not rendered if the <see cref="IImage"/> passed down to this tag helper is <see langword="null"/>.</para>
/// </summary>
/// <param name="tagHelperRenderer">The tag helper renderer.</param>
[HtmlTargetElement(ImgTagName, ParentTag = PictureTagName, TagStructure = TagStructure.NormalOrSelfClosing)]
public sealed class DropPictureImageTagHelper(IDropPictureImageTagHelperRenderer tagHelperRenderer) : DropImageTagHelperBase
{
    /// <summary>
    /// The tag helper renderer.
    /// </summary>
    private readonly IDropPictureImageTagHelperRenderer _tagHelperRenderer = tagHelperRenderer;

    /// <inheritdoc/>
    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        if (TryGetModelFromContext(context, out var model) is false)
        {
            await base.ProcessAsync(context, output);
            return;
        }

        var loadingMode = GetLoadingModeOrDefaultFromContext(context);
        var rendererContext = new DropImageTagHelperRendererContext(model, loadingMode);

        await _tagHelperRenderer.RenderAsync(rendererContext, context, output);
    }

    private static bool TryGetModelFromContext(TagHelperContext context, [NotNullWhen(true)] out IImage? model)
    {
        if (context.Items.ContainsKey(DropLoadingModeContextItemName) is false)
        {
            model = default;
            return false;
        }

        model = context.Items[DropModelContextItemName] as IImage;
        return model is not null;
    }

    private static LoadingMode GetLoadingModeOrDefaultFromContext(TagHelperContext context)
    {
        if (context.Items.ContainsKey(DropLoadingModeContextItemName) is false)
        {
            return LoadingMode.Default;
        }

        return context.Items[DropLoadingModeContextItemName] as LoadingMode? ?? LoadingMode.Default;
    }
}