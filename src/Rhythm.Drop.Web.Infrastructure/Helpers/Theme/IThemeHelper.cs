namespace Rhythm.Drop.Web.Infrastructure.Helpers.Theme;

/// <summary>
/// A contract to create a helper for themes.
/// </summary>
public interface IThemeHelper
{
    /// <summary>
    /// Gets the theme or default theme if the provided theme is invalid.
    /// </summary>
    /// <param name="theme">The theme.</param>
    /// <returns>A <see cref="string"/>.</returns>
    string GetValidTheme(string? theme);
}