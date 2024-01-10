namespace Rhythm.Drop.Web.Options;

/// <summary>
/// Configuration options for Rhythm Drop Components.
/// </summary>
public sealed class ComponentsOptions
{
    /// <summary>
    /// The name of the section for configuration.
    /// </summary>
    public const string SectionName = "Rhythm:Drop:Components";

    /// <summary>
    /// Gets or sets the default theme.
    /// </summary>
    /// <remarks>This theme is used if no other theme is set at runtime.</remarks>
    public string DefaultTheme { get; set; } = "Default";

    /// <summary>
    /// Gets or sets the pattern to find a view.
    /// </summary>
    public string ViewPathPattern { get; set; } = "~/Views/DropComponents/{Theme}/{ViewName}.cshtml";
}