namespace Rhythm.Drop.Web.Helpers.Rendering;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Options;
using System;

/// <summary>
/// The default implementation of <see cref="IViewPathHelper"/>.
/// </summary>
/// <param name="optionsMonitor">The options monitor.</param>
internal sealed class DefaultViewPathHelper(IOptionsMonitor<RenderingOptions> optionsMonitor) : IViewPathHelper
{
    /// <summary>
    /// The options monitor.
    /// </summary>
    private readonly IOptionsMonitor<RenderingOptions> _optionsMonitor = optionsMonitor;

    /// <inheritdoc/>
    public string GetViewPath(MetaData metaData)
    {
        var options = _optionsMonitor.CurrentValue;
        var viewName = GetViewName(metaData);
        var itemType = GetItemType(metaData, options.ItemTypes);

        return options.ViewPathPattern
            .Replace("{Theme}", metaData.Theme)
            .Replace("{ItemType}", itemType)
            .Replace("{ViewName}", viewName);
    }

    private static string GetViewName(MetaData metaData)
    {
        return metaData switch
        {
            ComponentMetaData componentMetaData => componentMetaData.GetComponent().ViewName,
            SubcomponentMetaData subcomponentMetaData => subcomponentMetaData.GetSubcomponent().ViewName,
            ModalMetaData modalMetaData => modalMetaData.GetModal().ViewName,
            _ => throw new NotSupportedException($"Unable to get view name for metadata type {metaData.GetType()}")
        };
    }

    private static string GetItemType(MetaData metaData, RenderingItemTypeOptions options)
    {
        return metaData switch
        {
            ComponentMetaData => options.Components,
            SubcomponentMetaData => options.Subcomponents,
            ModalMetaData => options.Modals,
            _ => throw new NotSupportedException($"Unable to get view name for metadata type {metaData.GetType()}")
        };
    }

}