namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Components;

using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Web.Infrastructure.MetaData;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Components;

[TestFixture]
public class DefaultDropComponentTagHelperRendererTests : DefaultDropComponentTagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_Returns_No_Output_Tag()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropComponentsTagHelperRenderer();
        var model = CreateRendererContext(new FakeComponent());
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
    public async Task RenderAsync_With_No_Component_Returns_No_Output()
    {
        // arrange
        var tagHelperRenderer = CreateDefaultDropComponentsTagHelperRenderer();
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


    private static DropComponentTagHelperRendererContext CreateRendererContext(IComponent? component)
    {
        var viewContext = CreateViewContext();

        return new DropComponentTagHelperRendererContext(component, ComponentMetaData.RootLevel, DefaultTheme, 0, 1, ReadOnlyHtmlAttributeCollection.Empty(), viewContext, default);
    }
}
