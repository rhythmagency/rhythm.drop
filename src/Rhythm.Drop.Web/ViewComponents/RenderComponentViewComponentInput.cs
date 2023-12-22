namespace Rhythm.Drop.Web.ViewComponents;

/// <summary>
/// The input required to render a component view component.
/// </summary>
/// <param name="Model">The component or component meta data.</param>
/// <param name="ViewPath">The view path to render the component with.</param>
public sealed record RenderComponentViewComponentInput(object Model, string ViewPath);