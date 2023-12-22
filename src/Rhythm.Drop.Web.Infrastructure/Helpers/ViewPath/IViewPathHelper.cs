namespace Rhythm.Drop.Web.Infrastructure.Helpers.ViewPath;

/// <summary>
/// A contract for implementing a helper for getting view paths.
/// </summary>
public interface IViewPathHelper
{
    /// <summary>
    /// Gets the view path for a component.
    /// </summary>
    /// <param name="theme">The theme.</param>
    /// <param name="viewName">The view name.</param>
    /// <returns>A <see cref="string"/> which represents the path to the view.</returns>
    string GetComponentViewPath(string theme, string viewName);
}