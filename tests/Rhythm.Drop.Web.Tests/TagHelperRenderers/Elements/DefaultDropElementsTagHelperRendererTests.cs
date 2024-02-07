namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Elements;
using Rhythm.Drop.Models.Elements;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;
using System.Threading.Tasks;

public class DefaultDropElementsTagHelperRendererTests : DefaultDropElementTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_Elements_And_No_TagName_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropElementsTagHelperRenderer();
        var model = CreateRendererContext([new FakeElement()]);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.Default);
        Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
    }

    [Test]
    public async Task RenderAsync_With_TagName_And_No_Elements_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropElementsTagHelperRenderer();
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
    public async Task RenderAsync_With_TagName_And_Elements_Returns_Output_With_Expected_TagName()
    {
        // arrange
        const string NewTagName = "section";
        var tagHelperRenderer = CreateDefaultDropElementsTagHelperRenderer();
        var model = CreateRendererContext([new FakeElement()], NewTagName);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.EqualTo(NewTagName));
    }

    private static DropElementsTagHelperRendererContext CreateRendererContext(IElement[] elements)
    {
        return CreateRendererContext(elements, default);
    }
    private static DropElementsTagHelperRendererContext CreateRendererContext(IElement[] elements, string? tagName)
    {
        var viewContext = CreateViewContext();

        return new DropElementsTagHelperRendererContext(elements, DefaultTheme, tagName, viewContext, default);
    }
}
