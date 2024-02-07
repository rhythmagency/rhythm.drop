namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Elements;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Elements;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Elements;

[TestFixture]
public class DefaultDropElementTagHelperRendererTests : DefaultDropElementTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_Returns_No_Output_Tag()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropElementsTagHelperRenderer();
        var model = CreateRendererContext(new FakeElement());
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
            Assert.That(output.Content.IsEmptyOrWhiteSpace, Is.False);
        });

    }

    [Test]
    public async Task RenderAsync_With_No_Element_Returns_No_Output()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropElementsTagHelperRenderer();
        var model = CreateRendererContext(default);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(model, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
            Assert.That(output.Content.IsEmptyOrWhiteSpace, Is.True);
        });
    }


    private static DropElementTagHelperRendererContext CreateRendererContext(IElement? element)
    {
        var viewContext = CreateViewContext();

        return new DropElementTagHelperRendererContext(element, DefaultTheme, 0, 1, ReadOnlyHtmlAttributeCollection.Empty(), viewContext, default);
    }
}
