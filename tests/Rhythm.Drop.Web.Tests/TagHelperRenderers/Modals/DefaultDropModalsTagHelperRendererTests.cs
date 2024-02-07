namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Modals;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;
using System.Threading.Tasks;

public class DefaultDropModalsTagHelperRendererTests : DefaultDropModalTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_Modals_And_No_TagName_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropModalsTagHelperRenderer();
        var model = CreateRendererContext([new FakeModal()]);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.Default);
        Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
    }

    [Test]
    public async Task RenderAsync_With_TagName_And_No_Modals_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropModalsTagHelperRenderer();
        var model = CreateRendererContext([]);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.Default);
        Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
    }

    [Test]
    public async Task RenderAsync_With_TagName_And_Modals_Returns_Output_With_Expected_TagName()
    {
        // arrange
        const string NewTagName = "section";
        var tagHelperRenderer = CreateDefaultDropModalsTagHelperRenderer();
        var model = CreateRendererContext([new FakeModal()], NewTagName);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.EqualTo(NewTagName));
    }

    private static DropModalsTagHelperRendererContext CreateRendererContext(IModal[] modals)
    {
        return CreateRendererContext(modals, default);
    }
    private static DropModalsTagHelperRendererContext CreateRendererContext(IModal[] modals, string? tagName)
    {
        var viewContext = CreateViewContext();

        return new DropModalsTagHelperRendererContext(modals, DefaultTheme, tagName, viewContext, default);
    }
}
