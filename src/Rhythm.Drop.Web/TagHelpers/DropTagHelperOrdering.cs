namespace Rhythm.Drop.Web.TagHelpers;

/// <summary>
/// Constants for which order tag helpers are rendered.
/// </summary>
public static class DropTagHelperOrdering
{
    /// <summary>
    /// Renders the tag helper before <see cref="Default"/>.
    /// </summary>
    /// <
    public const int PreDefault = -1;

    /// <summary>
    /// Renders the tag helper at default.
    /// </summary>
    public const int Default = 0;

    /// <summary>
    /// Renders the tag helper after <see cref="Default"/>.
    /// </summary>
    public const int PostDefault = 1;
}