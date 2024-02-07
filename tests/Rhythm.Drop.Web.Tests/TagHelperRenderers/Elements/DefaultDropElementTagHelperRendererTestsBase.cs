namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Elements;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;
using Rhythm.Drop.Web.TagHelperRenderers.Elements;
using System.Threading.Tasks;

public abstract class DefaultDropElementTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected const string DefaultTheme = "Default";



    protected static IRenderingHelper CreateRenderingHelper()
    {
        return CreateRenderingHelper(new HtmlString("<div>Test</div>"));
    }

    protected static IRenderingHelper CreateRenderingHelper(IHtmlContent htmlContent)
    {
        var mock = new Mock<IRenderingHelper>();
        mock.Setup(x => x.RenderAsync(It.IsAny<ElementMetaData>())).Returns(Task.FromResult(htmlContent));

        return mock.Object;
    }

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

    protected static ViewContext CreateViewContext()
    {
        return Mock.Of<ViewContext>();
    }
}
