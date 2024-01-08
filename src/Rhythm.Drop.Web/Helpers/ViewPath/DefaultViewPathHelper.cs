namespace Rhythm.Drop.Web.Helpers.ViewPath;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.ViewPath;
using Rhythm.Drop.Web.Options;

/// <summary>
/// The default implementation of <see cref="IViewPathHelper"/>.
/// </summary>
internal sealed class DefaultViewPathHelper : IViewPathHelper
{
    private readonly IOptionsMonitor<ComponentsOptions> _optionsMonitor;

    public DefaultViewPathHelper(IOptionsMonitor<ComponentsOptions> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;
    }

    /// <inheritdoc/>
    public string GetComponentViewPath(string theme, string viewName)
    {
        var options = _optionsMonitor.CurrentValue;

        return options.ViewPathPattern
            .Replace("{Theme}", theme)
            .Replace("{ViewName}", viewName);
    }
}