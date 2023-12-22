namespace Rhythm.Drop.Web.Options;

using Rhythm.Drop.Models.Components;

/// <summary>
/// Defaults configuration options for Rhythm Drop Components.
/// </summary>
public sealed class ComponentsDefaultsOptions
{
    /// <summary>
    /// Gets or sets the default theme.
    /// 
    /// This theme is used if no other theme is set at runtime.
    /// </summary>
    public string Theme { get; set; } = "Default";
}