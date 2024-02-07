namespace Rhythm.Drop.Web.Factories.MetaData;

using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.MetaData;
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