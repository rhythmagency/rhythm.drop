namespace Rhythm.Drop.Web.Helpers.Rendering;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Options;
using System;

/// <summary>
/// An abstract implementation of <see cref="IViewPathHelper"/>.
/// </summary>
/// <param name="optionsMonitor">The options monitor.</param>
public abstract class ViewPathHelperBase(IOptionsMonitor<RenderingOptions> optionsMonitor) : IViewPathHelper
{
    /// <summary>
    /// The options monitor.
    /// </summary>
    protected readonly IOptionsMonitor<RenderingOptions> _optionsMonitor = optionsMonitor;

    /// <inheritdoc/>
    public virtual string GetViewPath(MetaData metaData)
    {
        var options = _optionsMonitor.CurrentValue;
        var viewName = GetViewName(metaData);
        var ViewType = GetViewType(metaData);

        return options.ViewPathPattern
            .Replace("{Theme}", metaData.Theme)
            .Replace("{ViewType}", ViewType)
            .Replace("{ViewName}", viewName);
    }

    /// <summary>
    /// Gets the view name for the a given <see cref="MetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data.</param>
    /// <returns>A <see cref="string"/>.</returns>
    /// <exception cref="NotSupportedException">When an unsupported meta data is provided as the <paramref name="metaData"/>.</exception>
    protected virtual string GetViewName(MetaData metaData)
    {
        return metaData switch
        {
            ComponentMetaData componentMetaData => GetComponentViewName(componentMetaData),
            SubcomponentMetaData subcomponentMetaData => GetSubcomponentViewName(subcomponentMetaData),
            ModalMetaData modalMetaData => GetModalViewName(modalMetaData),
            _ => throw new NotSupportedException($"Unable to get view name for metadata type {metaData.GetType()}")
        };
    }

    /// <summary>
    /// Gets the view type for the a given <see cref="MetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data.</param>
    /// <returns>A <see cref="string"/>.</returns>
    /// <exception cref="NotSupportedException">When an unsupported meta data is provided as the <paramref name="metaData"/>.</exception>
    protected virtual string GetViewType(MetaData metaData)
    {
        return metaData switch
        {
            ComponentMetaData componentMetaData => GetComponentViewType(componentMetaData),
            SubcomponentMetaData subcomponentMetaData => GetSubcomponentViewType(subcomponentMetaData),
            ModalMetaData modalMetaData => GetModalViewType(modalMetaData),
            _ => throw new NotSupportedException($"Unable to get view type for metadata type {metaData.GetType()}")
        };
    }

    /// <summary>
    /// Gets the view name for a given <see cref="ComponentMetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected virtual string GetComponentViewName(ComponentMetaData metaData)
    {
        return metaData.GetComponent().ViewName;
    }

    /// <summary>
    /// Gets the view name for a given <see cref="ModalMetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected virtual string GetModalViewName(ModalMetaData metaData)
    {
        return metaData.GetModal().ViewName;
    }

    /// <summary>
    /// Gets the view name for a given <see cref="SubcomponentMetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected virtual string GetSubcomponentViewName(SubcomponentMetaData metaData)
    {
        return metaData.GetSubcomponent().ViewName;
    }

    /// <summary>
    /// Gets the view type for a given <see cref="ComponentMetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected virtual string GetComponentViewType(ComponentMetaData metaData)
    {
        return _optionsMonitor.CurrentValue.ViewTypes.Components;
    }

    /// <summary>
    /// Gets the view type for a given <see cref="ModalMetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected virtual string GetModalViewType(ModalMetaData metaData)
    {
        return _optionsMonitor.CurrentValue.ViewTypes.Modals;
    }

    /// <summary>
    /// Gets the view type for a given <see cref="SubcomponentMetaData"/>.
    /// </summary>
    /// <param name="metaData">The meta data</param>
    /// <returns>A <see cref="string"/>.</returns>
    protected virtual string GetSubcomponentViewType(SubcomponentMetaData metaData)
    {
        return _optionsMonitor.CurrentValue.ViewTypes.Subcomponents;
    }
}

