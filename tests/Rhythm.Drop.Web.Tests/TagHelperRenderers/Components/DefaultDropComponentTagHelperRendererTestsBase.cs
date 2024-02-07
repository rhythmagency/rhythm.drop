namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Components;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Rhythm.Drop.Web.Factories.Components;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using Rhythm.Drop.Web.TagHelperRenderers.Components;
using System.Threading.Tasks;

public abstract class DefaultDropComponentTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected const string DefaultTheme = "Default";



    protected static IRenderingHelper CreateRenderingHelper()
    {
        return CreateRenderingHelper(new HtmlString("<div>Test</div>"));
    }

    protected static IRenderingHelper CreateRenderingHelper(IHtmlContent htmlContent)
    {
        var mock = new Mock<IRenderingHelper>();
        mock.Setup(x => x.RenderAsync(It.IsAny<ComponentMetaData>())).Returns(Task.FromResult(htmlContent));

        return mock.Object;
    }

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

    protected static ViewContext CreateViewContext()
    {
        return Mock.Of<ViewContext>();
    }
}
