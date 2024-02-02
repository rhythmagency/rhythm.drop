namespace Rhythm.Drop.Web.Factories.Components;

using Rhythm.Drop.Web.Infrastructure.Factories.Components;
using Rhythm.Drop.Web.Infrastructure.MetaData.Components;
using System;

/// <summary>
/// The default implementation of <see cref="IComponentMetaDataFactory"/>.
/// </summary>
internal sealed class DefaultComponentMetaDataFactory : IComponentMetaDataFactory
{
    /// <inheritdoc/>
    public ComponentMetaData Create(ComponentMetaDataFactoryInput input)
    {
        Type componentType = input.Component.GetType();
        Type genericType = typeof(ComponentMetaData<>).MakeGenericType(componentType);
        var instance = Activator.CreateInstance(genericType, [input.Component, input.Level, input.Index, input.Total, input.Theme, input.Attributes, input.Section]);

        if (instance is not ComponentMetaData metaData)
        {
            throw new InvalidOperationException("Unable to create component meta data");
        }

        return metaData;
    }
}