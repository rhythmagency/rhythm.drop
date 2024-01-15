namespace Rhythm.Drop.Web.Factories.Components;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Web.Infrastructure.Factories.Components;
using System;

/// <summary>
/// The default implementation of <see cref="IComponentMetaDataFactory"/>.
/// </summary>
internal sealed class DefaultComponentMetaDataFactory : IComponentMetaDataFactory
{
    /// <inheritdoc/>
    public ComponentMetaData Create(IComponent component, int level, int index, int total, string theme, IReadOnlyHtmlAttributeCollection attributes)
    {
        Type componentType = component.GetType();
        Type genericType = typeof(ComponentMetaData<>).MakeGenericType(componentType);
        var instance = Activator.CreateInstance(genericType, new object[] { component, level, index, total, theme, attributes });

        if (instance is not ComponentMetaData metaData)
        {
            throw new InvalidOperationException("Unable to create component meta data");
        }

        return metaData;
    }
}