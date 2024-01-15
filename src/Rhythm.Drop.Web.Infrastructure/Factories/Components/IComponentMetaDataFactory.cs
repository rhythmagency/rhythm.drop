namespace Rhythm.Drop.Web.Infrastructure.Factories.Components;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;

/// <summary>
/// A factory for creating Component Meta Data.
/// </summary>
public interface IComponentMetaDataFactory
{
    /// <summary>
    /// Creates a <see cref="ComponentMetaData"/> for a given input.
    /// </summary>
    /// <param name="component">The component.</param>
    /// <param name="level">The level of the component.</param>
    /// <param name="index">The index of the component within the current collection of components.</param>
    /// <param name="total">The total number of components within the current collection of components.</param>
    /// <param name="theme">The theme of the component.</param>
    /// <param name="attributes">The attributes to be passed to the component.</param>
    /// <returns>A <see cref="ComponentMetaData"/>.</returns>
    ComponentMetaData Create(IComponent component, int level, int index, int total, string theme, IReadOnlyHtmlAttributeCollection attributes);
}