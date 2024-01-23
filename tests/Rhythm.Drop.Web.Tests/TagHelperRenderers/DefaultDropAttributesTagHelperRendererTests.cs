namespace Rhythm.Drop.Web.Tests.TagHelperRenderers;

using Microsoft.AspNetCore.Razor.TagHelpers;
using Rhythm.Drop.Models.Common.Attributes;
using Rhythm.Drop.Web.TagHelperRenderers.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

[TestFixture]
public class DefaultDropAttributesTagHelperRendererTests : TagHelperRendererTestsBase
{
    private const string TestAttributeName = "data-test";

    [Test]
    public async Task RenderAsync_With_Attributes_Should_Return_Attributes()
    {
        // arrange
        var context = CreateTagHelperContext(DefaultTagName);
        var output = CreateTagHelperOutput(DefaultTagName);
        var tagHelpererRenderer = new DefaultDropAttributesTagHelperRenderer();

        var attributes = new HtmlAttributeCollection();
        attributes.SetAttribute(TestAttributeName, true);

        // act
        await tagHelpererRenderer.RenderAsync(attributes, context, output);

        Assert.That(output.Attributes, Has.Count.EqualTo(attributes.Count));
    }

    [Test]
    public async Task RenderAsync_With_Attributes_Should_Return_Additional_Attributes()
    {
        // arrange
        var existingAttributes = new List<TagHelperAttribute>()
        {
            new(TestAttributeName, true)
        };
        var context = CreateTagHelperContext(DefaultTagName, existingAttributes);
        var output = CreateTagHelperOutput(DefaultTagName, existingAttributes);
        var tagHelpererRenderer = new DefaultDropAttributesTagHelperRenderer();

        var attributes = new HtmlAttributeCollection();
        attributes.SetAttribute("data-new", true);

        // act
        await tagHelpererRenderer.RenderAsync(attributes, context, output);

        Assert.That(output.Attributes, Has.Count.EqualTo(attributes.Count + existingAttributes.Count));
    }

    [Test]
    public async Task RenderAsync_With_Attributes_Should_Return_Overridden_Attributes()
    {
        // arrange
        const bool OldValue = true;
        const bool NewValue = true;
        var existingAttributes = new List<TagHelperAttribute>()
        {
            new(TestAttributeName, OldValue)
        };
        var context = CreateTagHelperContext(DefaultTagName, existingAttributes);
        var output = CreateTagHelperOutput(DefaultTagName, existingAttributes);
        var tagHelpererRenderer = new DefaultDropAttributesTagHelperRenderer();

        var attributes = new HtmlAttributeCollection();
        attributes.SetAttribute(TestAttributeName, NewValue);

        // act
        await tagHelpererRenderer.RenderAsync(attributes, context, output);

        Assert.That(output.Attributes, Has.Count.EqualTo(attributes.Count));
        Assert.That(output.Attributes, Has.Exactly(1).Matches<TagHelperAttribute>(x => x.Name == TestAttributeName && x.Value.ToString() == NewValue.ToString()));
    }

    [Test]
    public async Task RenderAsync_With_No_Attributes_Should_Return_Existing_Attributes()
    {
        // arrange
        var existingAttributes = new List<TagHelperAttribute>()
        {
            new(TestAttributeName, true)
        };
        var context = CreateTagHelperContext(DefaultTagName, existingAttributes);
        var output = CreateTagHelperOutput(DefaultTagName, existingAttributes);
        var tagHelpererRenderer = new DefaultDropAttributesTagHelperRenderer();
        HtmlAttributeCollection? attributes = default;

        // act
        await tagHelpererRenderer.RenderAsync(attributes, context, output);

        Assert.That(output.Attributes, Has.Count.EqualTo(existingAttributes.Count));
    }
}
