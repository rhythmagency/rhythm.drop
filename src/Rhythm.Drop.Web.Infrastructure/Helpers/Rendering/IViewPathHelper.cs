namespace Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;

using Rhythm.Drop.Web.Infrastructure.MetaData;

/// <summary>
/// A contract for implementing a helper for getting view paths.
/// </summary>
public interface IViewPathHelper
{
    /// <summary>
    /// Gets the view path for a meta data.
    /// </summary>
    /// <param name="metaData">The meta data.</param>
    /// <returns>A <see cref="string"/> which represents the path to the view.</returns>
    string GetViewPath(MetaData metaData);
}