namespace Rhythm.Drop.Web.Infrastructure.Factories.Components;

using Rhythm.Drop.Web.Infrastructure.MetaData.Components;

/// <summary>
/// A factory for creating Component Meta Data.
/// </summary>
public interface IComponentMetaDataFactory
{
    /// <summary>
    /// Creates a <see cref="ComponentMetaData"/> for a given input.
    /// </summary>
    /// <param name="input">The input required to create a <see cref="ComponentMetaData"/> object.</param>
    /// <returns>A <see cref="ComponentMetaData"/>.</returns>
    ComponentMetaData Create(ComponentMetaDataFactoryInput input);
}