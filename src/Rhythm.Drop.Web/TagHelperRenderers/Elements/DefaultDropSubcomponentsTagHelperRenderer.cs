namespace Rhythm.Drop.Web.TagHelperRenderers.Subcomponents;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropSubcomponentsTagHelperRenderer"/>.
/// </summary>
/// <param name="subcomponentMetaDataFactory">The subcomponent meta data factory.</param>
/// <param name="renderingHelper">The rendering helper.</param>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropSubcomponentsTagHelperRenderer(ISubcomponentMetaDataFactory subcomponentMetaDataFactory, IRenderingHelper renderingHelper) : DropSubcomponentsTagHelperRendererBase
{
    /// <summary>
    /// The subcomponent meta data factory.
    /// </summary>
    private readonly ISubcomponentMetaDataFactory _subcomponentMetaDataFactory = subcomponentMetaDataFactory;

    /// <summary>
    /// The HTML helper.
    /// </summary>
    private readonly IRenderingHelper _renderingHelper = renderingHelper;

    /// <inheritdoc/>
    protected override async Task RenderMultipleAsync(DropSubcomponentsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = model.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        var subcomponents = model.Subcomponents;
        var total = subcomponents.Count;
        var index = 0;

        _renderingHelper.Contextualize(model.ViewContext);

        var attributes = ReadOnlyHtmlAttributeCollection.Empty();
        foreach (var subcomponent in subcomponents)
        {
            var input = new SubcomponentMetaDataFactoryInput(subcomponent, model.Level, index, total, model.Theme, attributes, model.Section);
            var viewModel = _subcomponentMetaDataFactory.Create(input);
            var content = await _renderingHelper.RenderAsync(viewModel);

            output.Content.AppendHtml(content);
            index++;
        }
    }

    /// <inheritdoc/>
    protected override async Task RenderSingleAsync(DropSubcomponentTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        var subcomponent = model.Subcomponent;
        if (subcomponent is null)
        {
            await RenderNullAsync(output);
            return;
        }
        output.SurpressTag();

        var input = new SubcomponentMetaDataFactoryInput(subcomponent, model.Level, model.Index, model.Total, model.Theme, model.Attributes, model.Section);
        var viewModel = _subcomponentMetaDataFactory.Create(input);

        _renderingHelper.Contextualize(model.ViewContext);

        var content = await _renderingHelper.RenderAsync(viewModel);
        output.Content.AppendHtml(content);
    }
}