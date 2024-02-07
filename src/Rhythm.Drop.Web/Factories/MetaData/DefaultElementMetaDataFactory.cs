﻿namespace Rhythm.Drop.Web.Factories.MetaData;

using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.MetaData;
using System;

/// <summary>
/// The default implementation of <see cref="IElementMetaDataFactory"/>.
/// </summary>
internal sealed class DefaultElementMetaDataFactory : DefaultMetaDataFactoryBase<ElementMetaDataFactoryInput, ElementMetaData>, IElementMetaDataFactory
{
    protected override object?[]? CreateInstanceParameters(ElementMetaDataFactoryInput input)
    {
        return [
            input.Element,
            input.Index,
            input.Total,
            input.Theme,
            input.Attributes,
            input.Section
        ];
    }

    protected override Type CreateInstanceType(ElementMetaDataFactoryInput input)
    {
        Type elementType = input.Element.GetType();

        return typeof(ElementMetaData<>).MakeGenericType(elementType);
    }
}