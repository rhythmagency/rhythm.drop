namespace Rhythm.Drop.Web.Helpers.Rendering;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using System.Threading.Tasks;

/// <summary>
/// The default implementation of <see cref="IRenderingHelper"/> which uses <see cref="IHtmlHelper"/>.
/// </summary>
/// <param name="htmlHelper">The HTML Helper.</param>
/// <param name="viewPathHelper">THe view path helper.</param>
internal sealed class DefaultRenderingHelper(IHtmlHelper htmlHelper, IViewPathHelper viewPathHelper) : IRenderingHelper
{
    /// <summary>
    /// The HTML helper.
    /// </summary>
    private readonly IHtmlHelper _htmlHelper = htmlHelper;

    /// <summary>
    /// The view path helper.
    /// </summary>
    private readonly IViewPathHelper _viewPathHelper = viewPathHelper;

    /// <inheritdoc/>
    public void Contextualize(ViewContext viewContext)
    {
        ((IViewContextAware)_htmlHelper).Contextualize(viewContext);
    }

    /// <inheritdoc/>
    public async Task<IHtmlContent> RenderAsync(ComponentMetaData metaData)
    {
        var viewPath = _viewPathHelper.GetComponentViewPath(metaData.Theme, metaData.ViewName());

        return await _htmlHelper.PartialAsync(viewPath, metaData);
    }
}