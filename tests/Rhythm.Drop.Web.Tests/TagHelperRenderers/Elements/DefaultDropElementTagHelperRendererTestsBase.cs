namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Elements;

using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;
using Rhythm.Drop.Web.TagHelperRenderers.Elements;

public abstract class DefaultDropElementTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected static IElementMetaDataFactory CreateElementMetaDataFactory()
    {
        return new DefaultElementMetaDataFactory();
    }

    protected static IDropElementsTagHelperRenderer CreateDefaultDropElementsTagHelperRenderer()
    {
        var elementMetaDataFactory = CreateElementMetaDataFactory();
        var renderingHelper = CreateRenderingHelper();
        return new DefaultDropElementsTagHelperRenderer(elementMetaDataFactory, renderingHelper);
    }
}
