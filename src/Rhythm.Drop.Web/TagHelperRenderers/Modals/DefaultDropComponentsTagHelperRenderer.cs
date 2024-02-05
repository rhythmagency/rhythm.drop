namespace Rhythm.Drop.Web.TagHelperRenderers.Modals;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Factories.Modals;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropModalsTagHelperRenderer"/>.
/// </summary>
/// <param name="modalMetaDataFactory">The modal meta data factory.</param>
/// <param name="renderingHelper">The rendering helper.</param>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropModalsTagHelperRenderer(IModalMetaDataFactory modalMetaDataFactory, IRenderingHelper renderingHelper) : DropModalsTagHelperRendererBase
{
    /// <summary>
    /// The modal meta data factory.
    /// </summary>
    private readonly IModalMetaDataFactory _modalMetaDataFactory = modalMetaDataFactory;

    /// <summary>
    /// The HTML helper.
    /// </summary>
    private readonly IRenderingHelper _renderingHelper = renderingHelper;

    /// <inheritdoc/>
    protected override async Task RenderMultipleAsync(DropModalsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = model.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        _renderingHelper.Contextualize(model.ViewContext);

        var attributes = ReadOnlyHtmlAttributeCollection.Empty();

        foreach (var modal in model.Modals)
        {
            var input = new ModalMetaDataFactoryInput(modal, model.Theme, attributes, model.Section);
            var viewModel = _modalMetaDataFactory.Create(input);
            var content = await _renderingHelper.RenderAsync(viewModel);

            output.Content.AppendHtml(content);
        }
    }

    /// <inheritdoc/>
    protected override async Task RenderSingleAsync(DropModalTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        var modal = model.Modal;
        if (modal is null)
        {
            await RenderNullAsync(output);
            return;
        }
        output.SurpressTag();

        var input = new ModalMetaDataFactoryInput(modal, model.Theme, model.Attributes, model.Section);
        var viewModel = _modalMetaDataFactory.Create(input);

        _renderingHelper.Contextualize(model.ViewContext);

        var content = await _renderingHelper.RenderAsync(viewModel);
        output.Content.AppendHtml(content);
    }
}