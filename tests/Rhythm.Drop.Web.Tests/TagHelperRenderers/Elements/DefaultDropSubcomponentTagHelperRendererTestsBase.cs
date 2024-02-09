namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Subcomponents;

using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;
using Rhythm.Drop.Web.TagHelperRenderers.Subcomponents;

public abstract class DefaultDropSubcomponentTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected static ISubcomponentMetaDataFactory CreateSubcomponentMetaDataFactory()
    {
        return new DefaultSubcomponentMetaDataFactory();
    }

    protected static IDropSubcomponentsTagHelperRenderer CreateDefaultDropSubcomponentsTagHelperRenderer()
    {
        var subcomponentMetaDataFactory = CreateSubcomponentMetaDataFactory();
        var renderingHelper = CreateRenderingHelper();
        return new DefaultDropSubcomponentsTagHelperRenderer(subcomponentMetaDataFactory, renderingHelper);
    }
}
