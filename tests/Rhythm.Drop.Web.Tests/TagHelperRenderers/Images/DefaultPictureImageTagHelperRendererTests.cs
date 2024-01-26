namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Images;

using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using Rhythm.Drop.Web.TagHelperRenderers.Images;
using System.Threading.Tasks;

[TestFixture]
public class DefaultPictureImageTagHelperRendererTests : TagHelperRendererTestsBase
{
    private const string ImgTagName = "img";
        
    [Test]
    public async Task RenderAsync_With_Valid_Image_Should_Return_Output_With_Modified_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropPictureTagHelperRenderer();
        var image = new Image("/image.gif", "Test", 200, 200);
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(ImgTagName);
        var output = CreateTagHelperOutput(ImgTagName);

        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        Assert.That(output.IsContentModified, Is.True);
    }

    [Test]
    public async Task RenderAsync_With_No_Valid_Image_Should_Return_Output_With_Suppressed_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropPictureTagHelperRenderer();
        var rendererContext = new DropImageTagHelperRendererContext(default, LoadingMode.Default);
        var context = CreateTagHelperContext(ImgTagName);
        var output = CreateTagHelperOutput(ImgTagName);

        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.Default);
            Assert.That(output.Content.IsEmptyOrWhiteSpace, Is.True);
        });
    }
}
