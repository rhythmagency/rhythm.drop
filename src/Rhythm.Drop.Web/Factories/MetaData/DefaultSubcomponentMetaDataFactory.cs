namespace Rhythm.Drop.Web.Factories.MetaData;

using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.MetaData;
using System;

/// <summary>
/// The default implementation of <see cref="ISubcomponentMetaDataFactory"/>.
/// </summary>
internal sealed class DefaultSubcomponentMetaDataFactory : DefaultMetaDataFactoryBase<SubcomponentMetaDataFactoryInput, SubcomponentMetaData>, ISubcomponentMetaDataFactory
{
    protected override object?[]? CreateInstanceParameters(SubcomponentMetaDataFactoryInput input)
    {
        return [
            input.Subcomponent,
            input.Level,
            input.Index,
            input.Total,
            input.Theme,
            input.Attributes,
            input.Section
        ];
    }

    protected override Type CreateInstanceType(SubcomponentMetaDataFactoryInput input)
    {
        Type subcomponentType = input.Subcomponent.GetType();

        return typeof(SubcomponentMetaData<>).MakeGenericType(subcomponentType);
    }
}