namespace Rhythm.Drop.Models.Components;

using Rhythm.Drop.Models.Common.Attributes;

/// <summary>
/// A generic type for Component Meta Data.
/// </summary>
/// <typeparam name="TComponent">The type of the component.</typeparam>
/// <param name="Component">The component.</param>
/// <param name="Level">The level of the component.</param>
/// <param name="Index">The index of the component within the current collection of components.</param>
/// <param name="Total">The total number of components within the current collection of components.</param>
/// <param name="Theme">The theme of the component.</param>
/// <param name="Attributes">The attributes to be passed to the component.</param>
public sealed record ComponentMetaData<TComponent>(TComponent Component, int Level, int Index, int Total, string Theme, IReadOnlyHtmlAttributeCollection Attributes) : ComponentMetaData(Level, Index, Total, Theme, Attributes) where TComponent : IComponent
{
}