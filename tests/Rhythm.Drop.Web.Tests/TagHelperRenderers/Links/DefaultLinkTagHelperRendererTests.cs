namespace Rhythm.Drop.Web.Tests.TagHelperRenderers.Links;

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Models.Links;
using Rhythm.Drop.Models.Modals;
using Rhythm.Drop.Web.TagHelperRenderers.Links;
using System.Threading.Tasks;

[TestFixture]
public class DefaultLinkTagHelperRendererTests : TagHelperRendererTestsBase
{
    private const string DefaultUrl = "#";

    private const string DefaultLabel = "Click Me";

    private const string HrefAttributeName = "href";

    [Test]
    public async Task RenderAsync_With_No_Link_Should_Return_Nothing()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropLinkTagHelperRenderer();
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        await tagHelperRenderer.RenderAsync(default, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.Not.EqualTo(DefaultTagName));
            Assert.That(output.Content.IsModified, Is.False);
        });
    }

    [Test]
    public async Task RenderAsync_With_Anchor_Link_Should_Return_Modified_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropLinkTagHelperRenderer();
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);
        var link = CreateAnchorLink(DefaultUrl);

        // act
        await tagHelperRenderer.RenderAsync(link, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.EqualTo("a"));
            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == HrefAttributeName && x.Value.ToString() == DefaultUrl));
            Assert.That(output.Content.IsModified, Is.True);
        });
    }

    [Test]
    public async Task RenderAsync_With_Modal_Link_Should_Return_Modified_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropLinkTagHelperRenderer();
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);

        // act
        var modal = new Modal("test", [new FakeComponent()]);
        var link = new ModalLink(modal, "Click Me", ReadOnlyHtmlAttributeCollection.Empty());

        // assert
        await tagHelperRenderer.RenderAsync(link, context, output);

        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.EqualTo("button"));
            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == "data-modal-target" && x.Value.ToString() == "test"));
            Assert.That(output.Content.IsModified, Is.True);
        });
    }

    [Test]
    public async Task RenderAsync_With_Link_And_Existing_Content_Should_Return_Only_Outter_Modified_Content()
    {
        // arrange
        var tagHelperRenderer = new DefaultDropLinkTagHelperRenderer();
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName, new HtmlString("Existing Content"));

        // act
        var link = CreateAnchorLink(DefaultUrl);
        await tagHelperRenderer.RenderAsync(link, context, output);

        // assert
        Assert.Multiple(() =>
        {
            Assert.That(output.TagName, Is.EqualTo("a"));
            Assert.That(output.Attributes, Has.One.Matches<TagHelperAttribute>(x => x.Name == HrefAttributeName && x.Value.ToString() == DefaultUrl));
            Assert.That(output.Content.IsModified, Is.False);
        });
    }

    private static AnchorLink CreateAnchorLink(string url)
    {
        var linkAttributes = new HtmlAttributeCollection();
        linkAttributes.SetAttribute("href", url);

        return new AnchorLink(DefaultLabel, linkAttributes.ToReadOnly());
    }
}
