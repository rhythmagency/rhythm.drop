namespace Rhythm.Drop.Web.Factories.MetaData;

using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.MetaData;
using System;

/// <summary>
/// The default implementation of <see cref="IComponentMetaDataFactory"/>.
/// </summary>
internal sealed class DefaultComponentMetaDataFactory : DefaultMetaDataFactoryBase<ComponentMetaDataFactoryInput, ComponentMetaData>, IComponentMetaDataFactory
{
    protected override object?[]? CreateInstanceParameters(ComponentMetaDataFactoryInput input)
    {
        return [
            input.Component,
            input.Level,
            input.Index,
            input.Total,
            input.Theme,
            input.Attributes,
            input.Section,
        ];
    }

    protected override Type CreateInstanceType(ComponentMetaDataFactoryInput input)
    {
        Type componentType = input.Component.GetType();

        return typeof(ComponentMetaData<>).MakeGenericType(componentType);
    }
}