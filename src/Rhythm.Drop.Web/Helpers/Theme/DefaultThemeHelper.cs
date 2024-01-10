namespace Rhythm.Drop.Web.Helpers.Theme;

using Microsoft.Extensions.Options;
using Rhythm.Drop.Web.Infrastructure.Helpers.Theme;
using Rhythm.Drop.Web.Options;

/// <summary>
/// The default implementation of <see cref="IThemeHelper"/>.
/// </summary>
internal sealed class DefaultThemeHelper : IThemeHelper
{
    private readonly IOptionsMonitor<ComponentsOptions> _optionsMonitor;

    public DefaultThemeHelper(IOptionsMonitor<ComponentsOptions> optionsMonitor)
    {
        _optionsMonitor = optionsMonitor;
    }

    /// <inheritdoc/>
    public string GetValidTheme(string? theme)
    {
        if (string.IsNullOrWhiteSpace(theme))
        {
            var options = _optionsMonitor.CurrentValue;
            return options.DefaultTheme;
        }

        return theme;
    }
}