namespace Rhythm.Drop.Web.Infrastructure;

/// <summary>
/// The loading mode for a web element.
/// </summary>
/// <remarks>This will typically be used by images or other components that have a variable way to loading assets at runtime.</remarks>
public enum LoadingMode
{
    /// <summary>
    /// The default loading mode.
    /// </summary>
    Default,

    /// <summary>
    /// Will instruct the tag helper renderer to load this with eager loading.
    /// </summary>
    Eager,

    /// <summary>
    /// Will instruct the tag helper renderer to load this with lazy loading.
    /// </summary>
    Lazy
}