namespace Rhythm.Drop.Web.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Infrastructure.Factories.Components;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Helpers.ViewPath;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using Rhythm.Drop.Web.ViewComponents;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropComponentsTagHelperRenderer"/>.
/// </summary>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropComponentsTagHelperRenderer(IComponentMetaDataFactory componentMetaDataFactory, IViewComponentHelper viewComponentHelper, IViewPathHelper viewPathHelper) : DropComponentsTagHelperRendererBase
{
    private readonly IComponentMetaDataFactory _componentMetaDataFactory = componentMetaDataFactory;

    private readonly IViewComponentHelper _viewComponentHelper = viewComponentHelper;

    private readonly IViewPathHelper _viewPathHelper = viewPathHelper;

    /// <inheritdoc/>
    protected override async Task RenderMultipleAsync(DropComponentsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = model.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        var components = model.Components;
        var total = components.Count;
        var index = 0;

        ((IViewContextAware)_viewComponentHelper).Contextualize(model.ViewContext);

        var attributes = ReadOnlyHtmlAttributeCollection.Empty();
        foreach (var component in components)
        {
            var viewModel = _componentMetaDataFactory.Create(component, model.Level, index, total, model.Theme, attributes);
            var viewPath = _viewPathHelper.GetComponentViewPath(model.Theme, component.ViewName);
            var input = new RenderComponentViewComponentInput(viewModel, viewPath);

            output.Content.AppendHtml(await _viewComponentHelper.InvokeAsync(typeof(RenderComponentViewComponent), input));
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
        var viewModel = _componentMetaDataFactory.Create(component, model.Level, model.Index, model.Total, model.Theme, model.Attributes);
        var viewPath = _viewPathHelper.GetComponentViewPath(model.Theme, component.ViewName);
        var input = new RenderComponentViewComponentInput(viewModel, viewPath);

        ((IViewContextAware)_viewComponentHelper).Contextualize(model.ViewContext);
        output.Content.AppendHtml(await _viewComponentHelper.InvokeAsync(typeof(RenderComponentViewComponent), input));
    }
}