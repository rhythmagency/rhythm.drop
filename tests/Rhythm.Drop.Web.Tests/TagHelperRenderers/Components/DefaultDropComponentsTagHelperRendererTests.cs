namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Components;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;
using System.Threading.Tasks;

public class DefaultDropComponentsTagHelperRendererTests : DefaultDropComponentTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_Components_And_No_TagName_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropComponentsTagHelperRenderer();
        var model = CreateRendererContext([new FakeComponent()]);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.Default);
        Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
    }

    [Test]
    public async Task RenderAsync_With_TagName_And_No_Components_Returns_Output_With_No_TagName()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropComponentsTagHelperRenderer();
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
    public async Task RenderAsync_With_TagName_And_Components_Returns_Output_With_Expected_TagName()
    {
        // arrange
        const string NewTagName = "section";
        var tagHelperRenderer = CreateDefaultDropComponentsTagHelperRenderer();
        var model = CreateRendererContext([new FakeComponent()], NewTagName);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.That(output.TagName, Is.EqualTo(NewTagName));
    }

    private static DropComponentsTagHelperRendererContext CreateRendererContext(IComponent[] components)
    {
        return CreateRendererContext(components, default);
    }
    private static DropComponentsTagHelperRendererContext CreateRendererContext(IComponent[] components, string? tagName)
    {
        var viewContext = CreateViewContext();

        return new DropComponentsTagHelperRendererContext(components, ComponentMetaData.RootLevel, DefaultTheme, tagName, viewContext, default);
    }
}
