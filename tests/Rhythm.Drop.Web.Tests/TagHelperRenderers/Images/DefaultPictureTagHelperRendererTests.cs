namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Images;

using Rhythm.Drop.Web.Infrastructure.TagHelperRenderers.Images;
using Rhythm.Drop.Web.Infrastructure;
using Rhythm.Drop.Web.TagHelperRenderers.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rhythm.Drop.Models.Images;
using Microsoft.AspNetCore.Html;

[TestFixture]
public class DefaultPictureTagHelperRendererTests : TagHelperRendererTestsBase
{
    private const string PictureTagName = "picture";

    private static readonly IHtmlContent _imgHtmlContent = new HtmlString("<img class=\"test\" />");

    [Test]
    public async Task RenderAsync_With_No_Existing_Img_Tag_Should_Return_Output_With_Modified_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropPictureTagHelperRenderer();
        var image = new Image("/image.gif", "Test", 200, 200);
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(PictureTagName);
        var output = CreateTagHelperOutput(PictureTagName);

        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        Assert.That(output.Content.IsModified, Is.True);
    }

    [Test]
    public async Task RenderAsync_With_Existing_Img_Tag_Should_Return_Output_With_No_Modified_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropPictureTagHelperRenderer();
        var image = new Image("/image.gif", "Test", 200, 200);
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(PictureTagName);
        var output = CreateTagHelperOutput(PictureTagName, _imgHtmlContent);

        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        Assert.That(output.Content.IsModified, Is.False);
    }

    [Test]
    public async Task RenderAsync_With_Img_And_Source_Tag_Should_Return_Output_With_Modified_PreContent()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropPictureTagHelperRenderer();
        var image = new Image("/image.gif", "Test", 200, 200, [ new ImageSource("/image2.gif")]);
        var rendererContext = new DropImageTagHelperRendererContext(image, LoadingMode.Default);
        var context = CreateTagHelperContext(PictureTagName);
        var output = CreateTagHelperOutput(PictureTagName, _imgHtmlContent);

        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        Assert.That(output.PreContent.IsModified, Is.True);
    }

    [Test]
    public async Task RenderAsync_With_No_Img_Should_Return_Surpressed_Output()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropPictureTagHelperRenderer();
        var rendererContext = new DropImageTagHelperRendererContext(default, LoadingMode.Default);
        var context = CreateTagHelperContext(PictureTagName);
        var output = CreateTagHelperOutput(PictureTagName, _imgHtmlContent);

        await tagHelperRenderer.RenderAsync(rendererContext, context, output);

        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.Default);
            Assert.That(output.PreContent.IsEmptyOrWhiteSpace, Is.True);
            Assert.That(output.Content.IsEmptyOrWhiteSpace, Is.True);
        });
    }
}
