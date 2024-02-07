namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Modals;

using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;
using Rhythm.Drop.Web.TagHelperRenderers.Modals;

public abstract class DefaultDropModalTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected static IModalMetaDataFactory CreateModalMetaDataFactory()
    {
        return new DefaultModalMetaDataFactory();
    }

    protected static IDropModalsTagHelperRenderer CreateDefaultDropModalsTagHelperRenderer()
    {
        var modalMetaDataFactory = CreateModalMetaDataFactory();
        var renderingHelper = CreateRenderingHelper();
        return new DefaultDropModalsTagHelperRenderer(modalMetaDataFactory, renderingHelper);
    }
}
