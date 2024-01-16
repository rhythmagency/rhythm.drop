namespace Rhythm.Drop.Web.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.Factories.Components;
using Rhythm.Drop.Web.Infrastructure.Helpers.ViewPath;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using System;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IDropComponentsTagHelperRenderer"/>.
/// </summary>
/// <param name="componentMetaDataFactory">The component meta data factory.</param>
/// <param name="htmlHelper">The HTML helper.</param>
/// <param name="viewPathHelper">The view path helper.</param>
/// <remarks>This implementation should cover most scenarios but can be replaced if needed on a project-by-project basis.</remarks>
internal sealed class DefaultDropComponentsTagHelperRenderer(IComponentMetaDataFactory componentMetaDataFactory, IHtmlHelper htmlHelper, IViewPathHelper viewPathHelper) : DropComponentsTagHelperRendererBase
{
    /// <summary>
    /// The component meta data factory.
    /// </summary>
    private readonly IComponentMetaDataFactory _componentMetaDataFactory = componentMetaDataFactory;

    /// <summary>
    /// The HTML helper.
    /// </summary>
    private readonly IHtmlHelper _htmlHelper = htmlHelper;

    /// <summary>
    /// The view path helper.
    /// </summary>
    private readonly IViewPathHelper _viewPathHelper = viewPathHelper;

    /// <inheritdoc/>
    protected override async Task RenderMultipleAsync(DropComponentsTagHelperRendererContext model, TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = model.TagName;
        output.TagMode = TagMode.StartTagAndEndTag;

        var components = model.Components;
        var total = components.Count;
        var index = 0;

        ((IViewContextAware)_htmlHelper).Contextualize(model.ViewContext);

        var attributes = ReadOnlyHtmlAttributeCollection.Empty();
        foreach (var component in components)
        {
            var input = new ComponentMetaDataFactoryInput(component, model.Level, index, total, model.Theme, attributes, model.Section);
            var viewModel = _componentMetaDataFactory.Create(input);
            var viewPath = _viewPathHelper.GetComponentViewPath(model.Theme, component.ViewName);

            output.Content.AppendHtml(await _htmlHelper.PartialAsync(viewPath, viewModel));
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
        var viewPath = _viewPathHelper.GetComponentViewPath(model.Theme, component.ViewName);

        ((IViewContextAware)_htmlHelper).Contextualize(model.ViewContext);
        output.Content.AppendHtml(await _htmlHelper.PartialAsync(viewPath, viewModel));
    }
}