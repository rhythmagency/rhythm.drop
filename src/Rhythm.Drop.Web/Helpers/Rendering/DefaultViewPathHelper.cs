namespace Rhythm.Drop.Web.Helpers.Rendering;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Options;

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
    public string GetComponentViewPath(string theme, string viewName)
    {
        var options = _optionsMonitor.CurrentValue;

        return options.ViewPathPattern
            .Replace("{Theme}", theme)
            .Replace("{ViewName}", viewName);
    }
}