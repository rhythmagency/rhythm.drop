namespace Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Rhythm.Drop.Models.Components;
using System.Threading.Tasks;

/// <summary>
/// A contract to create a helper for rendering.
/// </summary>
public interface IRenderingHelper : IViewContextAware
{
    /// <summary>
    /// Renders a meta data with a given path. 
    /// </summary>
    /// <param name="metaData">The meta data to render.</param>
    /// <returns>A <see cref="Task"/> containing a <see cref="IHtmlContent"/> object.</returns>
    Task<IHtmlContent> RenderAsync(ComponentMetaData metaData);
}
