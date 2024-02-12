namespace Rhythm.Drop.Web.Options;

/// <summary>
/// Configuration options for Rhythm Drop Rendering View Types.
/// </summary>
public sealed class RenderingViewTypeOptions
{
    /// <summary>
    /// Gets or sets the view type name for Modals.
    /// </summary>
    public string Components { get; set; } = "Components";

    /// <summary>
    /// Gets or sets the view type name for Subcomponents.
    /// </summary>
    public string Subcomponents { get; set; } = "Subcomponents";

    /// <summary>
    /// Gets or sets the view type name for Modals.
    /// </summary>
    public string Modals { get; set; } = "Modals";
}