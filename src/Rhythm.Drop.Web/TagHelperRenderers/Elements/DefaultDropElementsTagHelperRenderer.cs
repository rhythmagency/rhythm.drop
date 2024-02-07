namespace Rhythm.Drop.Web.TagHelperRenderers.Elements;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Factories.Elements;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropElementsTagHelperRenderer"/>.
/// </summary>
/// <param name="elementMetaDataFactory">The element meta data factory.</param>
/// <param name="renderingHelper">The rendering helper.</param>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropElementsTagHelperRenderer(IElementMetaDataFactory elementMetaDataFactory, IRenderingHelper renderingHelper) : DropElementsTagHelperRendererBase
{
    /// <summary>
    /// The element meta data factory.
    /// </summary>
    private readonly IElementMetaDataFactory _elementMetaDataFactory = elementMetaDataFactory;

    /// <summary>
    /// The HTML helper.
    /// </summary>
    private readonly IRenderingHelper _renderingHelper = renderingHelper;

    /// <inheritdoc/>
    protected override async Task RenderMultipleAsync(DropElementsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = model.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        var elements = model.Elements;
        var total = elements.Count;
        var index = 0;

        _renderingHelper.Contextualize(model.ViewContext);

        var attributes = ReadOnlyHtmlAttributeCollection.Empty();
        foreach (var element in elements)
        {
            var input = new ElementMetaDataFactoryInput(element, index, total, model.Theme, attributes, model.Section);
            var viewModel = _elementMetaDataFactory.Create(input);
            var content = await _renderingHelper.RenderAsync(viewModel);

            output.Content.AppendHtml(content);
            index++;
        }
    }

    /// <inheritdoc/>
    protected override async Task RenderSingleAsync(DropElementTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        var element = model.Element;
        if (element is null)
        {
            await RenderNullAsync(output);
            return;
        }
        output.SurpressTag();

        var input = new ElementMetaDataFactoryInput(element, model.Index, model.Total, model.Theme, model.Attributes, model.Section);
        var viewModel = _elementMetaDataFactory.Create(input);

        _renderingHelper.Contextualize(model.ViewContext);

        var content = await _renderingHelper.RenderAsync(viewModel);
        output.Content.AppendHtml(content);
    }
}