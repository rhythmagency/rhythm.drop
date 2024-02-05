namespace Rhythm.Drop.Web.Factories;

using Rhythm.Drop.Web.Infrastructure.Factories;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using System;

internal abstract class DefaultMetaDataFactoryBase<TInput, TMetaData> : IMetaDataFactory<TInput, TMetaData> where TMetaData : MetaData
{
    public TMetaData Create(TInput input)
    {
        var instanceType = CreateInstanceType(input);
        var instanceParameters = CreateInstanceParameters(input);
        var instance = Activator.CreateInstance(instanceType, instanceParameters);

        if (instance is not TMetaData metaData)
        {
            throw new InvalidOperationException($"Unable to create meta data of type {typeof(TMetaData)}");
        }

        return metaData;
    }

    protected abstract object?[]? CreateInstanceParameters(TInput input);

    protected abstract Type CreateInstanceType(TInput input);
}
