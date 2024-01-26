namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Images;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using Rhythm.Drop.Web.TagHelperRenderers.Images;
using System.Threading.Tasks;

[TestFixture]
public class DefaultImageTagHelperRendererTests : TagHelperRendererTestsBase
{
    [Test]
    public async Task RenderAsync_With_No_Image_Returns_No_Output()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropImageTagHelperRenderer();
        var rendererContext = new DropImageTagHelperRendererContext(default, LoadingMode.Default);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
            Assert.That(output.Content.IsModified, Is.False);
        });
    }

    [Test]
    public async Task RenderAsync_With_Simple_Image_Returns_Output_With_Img_TagName()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropImageTagHelperRenderer();
        var image = new Image("/image.gif", "Test");
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.EqualTo("img"));
            Assert.That(output.Content.IsModified, Is.False);

            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "src" && x.Value.ToString() == image.Url));
            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "alt" && x.Value.ToString() == image.AltText));
        });
    }

    public async Task RenderAsync_With_Simple_Image_And_Dimensions_Returns_Output_With_Img_TagName_And_Attributes()
    {        
        // arrange
        var tagHelperRenderer = new DefaultDropImageTagHelperRenderer();
        var image = new Image("/image.gif", "Test", 200, 200);
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.EqualTo("img"));
            Assert.That(output.Content.IsModified, Is.False);

            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "src" && x.Value.ToString() == image.Url));
            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "alt" && x.Value.ToString() == image.AltText));

            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "width" && x.Value.ToString() == image.Width.ToString()));
            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "height" && x.Value.ToString() == image.Height.ToString()));
        });
    }


    [Test]
    public async Task RenderAsync_With_Image_That_Has_Sources_Returns_Output_With_Picture_TagName()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropImageTagHelperRenderer();
        var image = new Image("/image.gif", "Test", default, default, [new ImageSource("/image2.gif")]);
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.EqualTo("picture"));
            Assert.That(output.Content.IsModified, Is.True);
        });
    }
}
