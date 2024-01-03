namespace Rhythm.Drop.Web.Infrastructure;

/// <summary>
/// The render mode for a web element.
/// </summary>
/// <remarks>This will typically be used by images or other components that have a variable way to render loading at runtime.</remarks>
public enum RenderMode
{
    /// <summary>
    /// The default render mode.
    /// </summary>
    Default,

    /// <summary>
    /// Will instruct the tag helper renderer to render this for eager loading.
    /// </summary>
    Eager,

    /// <summary>
    /// Will instruct the tag helper renderer to render this for lazy loading.
    /// </summary>
    Lazy
}