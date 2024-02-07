namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Modals;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moq;
using Rhythm.Drop.Web.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Factories.MetaData;
using Rhythm.Drop.Web.Infrastructure.Helpers.Rendering;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;
using Rhythm.Drop.Web.TagHelperRenderers.Modals;
using System.Threading.Tasks;

public abstract class DefaultDropModalTagHelperRendererTestsBase : TagHelperRendererTestsBase
{
    protected const string DefaultTheme = "Default";



    protected static IRenderingHelper CreateRenderingHelper()
    {
        return CreateRenderingHelper(new HtmlString("<div>Test</div>"));
    }

    protected static IRenderingHelper CreateRenderingHelper(IHtmlContent htmlContent)
    {
        var mock = new Mock<IRenderingHelper>();
        mock.Setup(x => x.RenderAsync(It.IsAny<ModalMetaData>())).Returns(Task.FromResult(htmlContent));

        return mock.Object;
    }

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

    protected static ViewContext CreateViewContext()
    {
        return Mock.Of<ViewContext>();
    }
}
