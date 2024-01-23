namespace Rhythm.Drop.Web.TagHelperRenderers.Components;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Factories.Components;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropComponentsTagHelperRenderer"/>.
/// </summary>
/// <param name="componentMetaDataFactory">The component meta data factory.</param>
/// <param name="renderingHelper">The rendering helper.</param>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropComponentsTagHelperRenderer(IComponentMetaDataFactory componentMetaDataFactory, IRenderingHelper renderingHelper) : DropComponentsTagHelperRendererBase
{
    /// <summary>
    /// The component meta data factory.
    /// </summary>
    private readonly IComponentMetaDataFactory _componentMetaDataFactory = componentMetaDataFactory;

    /// <summary>
    /// The HTML helper.
    /// </summary>
    private readonly IRenderingHelper _renderingHelper = renderingHelper;

    /// <inheritdoc/>
    protected override async Task RenderMultipleAsync(DropComponentsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = model.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        var components = model.Components;
        var total = components.Count;
        var index = 0;

        _renderingHelper.Contextualize(model.ViewContext);

        var attributes = ReadOnlyHtmlAttributeCollection.Empty();
        foreach (var component in components)
        {
            var input = new ComponentMetaDataFactoryInput(component, model.Level, index, total, model.Theme, attributes, model.Section);
            var viewModel = _componentMetaDataFactory.Create(input);
            
            output.Content.AppendHtml(await _renderingHelper.RenderAsync(viewModel));
            index++;
        }
    }

    /// <inheritdoc/>
    protected override async Task RenderSingleAsync(DropComponentTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        var component = model.Component;
        if (component is null)
        {
            await RenderNullAsync(output);
            return;
        }
        output.SurpressTag();

        var input = new ComponentMetaDataFactoryInput(component, model.Level, model.Index, model.Total, model.Theme, model.Attributes, model.Section);
        var viewModel = _componentMetaDataFactory.Create(input);
        
        _renderingHelper.Contextualize(model.ViewContext);
        output.Content.AppendHtml(await _renderingHelper.RenderAsync(viewModel));
    }
}