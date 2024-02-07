namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Components;

using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using Rhythm.Drop.Web.TagHelperRenderers.Components;

public abstract class DefaultDropComponentTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected static IComponentMetaDataFactory CreateComponentMetaDataFactory()
    {
        return new DefaultComponentMetaDataFactory();
    }

    protected static IDropComponentsTagHelperRenderer CreateDefaultDropComponentsTagHelperRenderer()
    {
        var componentMetaDataFactory = CreateComponentMetaDataFactory();
        var renderingHelper = CreateRenderingHelper();
        return new DefaultDropComponentsTagHelperRenderer(componentMetaDataFactory, renderingHelper);
    }
}
