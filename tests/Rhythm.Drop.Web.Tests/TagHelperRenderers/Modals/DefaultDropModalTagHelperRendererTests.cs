namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Modals;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Modals;

[TestFixture]
public class DefaultDropModalTagHelperRendererTests : DefaultDropModalTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_No_TagName_Returns_No_Output_Tag()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropModalsTagHelperRenderer();
        var model = CreateRendererContext(new FakeModal());
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
    public async Task RenderAsync_With_No_Modal_Returns_No_Output()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropModalsTagHelperRenderer();
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


    private static DropModalTagHelperRendererContext CreateRendererContext(IModal? modal)
    {
        var viewContext = CreateViewContext();

        return new DropModalTagHelperRendererContext(modal, DefaultTheme, ReadOnlyHtmlAttributeCollection.Empty(), viewContext, default);
    }
}
