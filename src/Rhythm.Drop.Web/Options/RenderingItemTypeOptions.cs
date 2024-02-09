namespace Rhythm.Drop.Web.Options;

/// <summary>
/// Configuration options for Rhythm Drop Rendering Item Types.
/// </summary>
public sealed class RenderingItemTypeOptions
{
    /// <summary>
    /// Gets or sets the item type name for Modals.
    /// </summary>
    public string Components { get; set; } = "Components";

    /// <summary>
    /// Gets or sets the item type name for Subcomponents.
    /// </summary>
    public string Subcomponents { get; set; } = "Subcomponents";

    /// <summary>
    /// Gets or sets the item type name for Modals.
    /// </summary>
    public string Modals { get; set; } = "Modals";
}