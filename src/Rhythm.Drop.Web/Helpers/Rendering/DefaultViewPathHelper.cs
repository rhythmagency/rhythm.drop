namespace Rhythm.Drop.Web.Helpers.Rendering;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.MetaData.Components;
using Rhythm.Drop.Web.Infrastructure.MetaData.Modals;
using Rhythm.Drop.Web.Options;
using System;

/// <summary>
/// The default implementation of <see cref="IViewPathHelper"/>.
/// </summary>
/// <param name="optionsMonitor">The options monitor.</param>
internal sealed class DefaultViewPathHelper(IOptionsMonitor<ComponentsOptions> optionsMonitor) : IViewPathHelper
{
    /// <summary>
    /// The options monitor.
    /// </summary>
    private readonly IOptionsMonitor<ComponentsOptions> _optionsMonitor = optionsMonitor;

    /// <inheritdoc/>
    public string GetViewPath(MetaData metaData)
    {
        var options = _optionsMonitor.CurrentValue;
        var viewName = GetViewName(metaData);

        return options.ViewPathPattern
            .Replace("{Theme}", metaData.Theme)
            .Replace("{ViewName}", viewName);
    }

    private static string GetViewName(MetaData metaData)
    {
        return metaData switch
        {
            ComponentMetaData componentMetaData => componentMetaData.GetComponent().ViewName,
            ModalMetaData modalMetaData => modalMetaData.GetModal().ViewName,
            _ => throw new NotSupportedException($"Unable to get view name for metadata type {metaData.GetType()}")
        };
    }
}