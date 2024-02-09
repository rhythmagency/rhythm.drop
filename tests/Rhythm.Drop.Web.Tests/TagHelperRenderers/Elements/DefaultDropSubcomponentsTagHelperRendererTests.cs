namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Subcomponents;
using Rhythm.Drop.Models.Subcomponents;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;
using System.Threading.Tasks;

public class DefaultDropSubcomponentsTagHelperRendererTests : DefaultDropSubcomponentTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_Subcomponents_And_No_TagName_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropSubcomponentsTagHelperRenderer();
        var model = CreateRendererContext([new FakeSubcomponent()]);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.Default);
        Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
    }

    [Test]
    public async Task RenderAsync_With_TagName_And_No_Subcomponents_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropSubcomponentsTagHelperRenderer();
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
    public async Task RenderAsync_With_TagName_And_Subcomponents_Returns_Output_With_Expected_TagName()
    {
        // arrange
        const string NewTagName = "section";
        var tagHelperRenderer = CreateDefaultDropSubcomponentsTagHelperRenderer();
        var model = CreateRendererContext([new FakeSubcomponent()], NewTagName);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.EqualTo(NewTagName));
    }

    private static DropSubcomponentsTagHelperRendererContext CreateRendererContext(ISubcomponent[] subcomponents)
    {
        return CreateRendererContext(subcomponents, default);
    }
    private static DropSubcomponentsTagHelperRendererContext CreateRendererContext(ISubcomponent[] subcomponents, string? tagName)
    {
        var viewContext = CreateViewContext();

        return new DropSubcomponentsTagHelperRendererContext(subcomponents, DefaultTheme, tagName, viewContext, default);
    }
}
