﻿namespace Rhythm.Drop.Web.Factories.Modals;

using Rhythm.Drop.Web.Infrastructure.Factories.Modals;
using Rhythm.Drop.Web.Infrastructure.MetaData.Modals;
using Rhythm.Drop.Web.MetaData.Modals;
using System;

/// <summary>
/// The default implementation of <see cref="IModalMetaDataFactory"/>.
/// </summary>
internal sealed class DefaultModalMetaDataFactory : DefaultMetaDataFactoryBase<ModalMetaDataFactoryInput, ModalMetaData>, IModalMetaDataFactory
{
    protected override object?[]? CreateInstanceParameters(ModalMetaDataFactoryInput input)
    {
        return [
            input.Modal,
            input.Theme,
            input.Attributes,
            input.Section,
        ];
    }

    protected override Type CreateInstanceType(ModalMetaDataFactoryInput input)
    {
        Type modalType = input.Modal.GetType();

        return typeof(ModalMetaData<>).MakeGenericType(modalType);
    }
}