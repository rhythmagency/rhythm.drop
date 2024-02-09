namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Subcomponents;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Subcomponents;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Subcomponents;

[TestFixture]
public class DefaultDropSubcomponentTagHelperRendererTests : DefaultDropSubcomponentTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_No_TagName_Returns_No_Output_Tag()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropSubcomponentsTagHelperRenderer();
        var model = CreateRendererContext(new FakeSubcomponent());
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
    public async Task RenderAsync_With_No_Subcomponent_Returns_No_Output()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropSubcomponentsTagHelperRenderer();
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


    private static DropSubcomponentTagHelperRendererContext CreateRendererContext(ISubcomponent? subcomponent)
    {
        var viewContext = CreateViewContext();

        return new DropSubcomponentTagHelperRendererContext(subcomponent, DefaultTheme, 0, 1, ReadOnlyHtmlAttributeCollection.Empty(), viewContext, default);
    }
}
