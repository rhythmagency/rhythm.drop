namespace Rhythm.Drop.Builders.Tests.Links.Url;

using Rhythm.Drop.Builders.Links;
using Rhythm.Drop.Models.Common.Attributes;

[TestFixture]
public class DefaultLinkBuilderTests
{
    private const string? NoUrl = default;

    private const string? Url = "/";

    private const string NoLabel = default;

    private const string Label = "Find Out More";

    private const string HrefAttributeName = "href";

    private const string TestAttributeName = "data-test";

    [TestCase(NoUrl, NoLabel)]
    [TestCase(NoUrl, Label)]
    [TestCase(Url, NoLabel)]
    public void Build_With_Invalid_Input_Should_Return_Default(string? url, string? label)
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithUrl(url)
            .AndLabel(label)
            .Build();

        Assert.That(link, Is.Default);
    }

    [Test]
    public void Build_With_Link_And_Label_Should_Return_Link()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithUrl(Url)
            .AndLabel(Label)
            .Build();

        Assert.That(link, Is.Not.Default);
    }

    [Test]
    public void Build_With_Link_And_Label_Should_Return_Link_With_Href_Attribute()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithUrl(Url)
            .AndLabel(Label)
            .Build();

        Assert.That(link, Is.Not.Default);
        Assert.That(link.Attributes, Has.Exactly(1).Matches<HtmlAttribute>(x => x.Name == HrefAttributeName));
    }

    [Test]
    public void Build_With_Valid_Link_And_Label_Attributes_Should_Return_Expected_Link()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithUrl(Url)
            .AndLabel(Label)
            .SetAttribute(TestAttributeName, true)
            .Build();

        Assert.That(link, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(link.Attributes, Has.Exactly(1).Matches<HtmlAttribute>(x => x.Name == HrefAttributeName));
            Assert.That(link.Attributes, Has.Exactly(1).Matches<HtmlAttribute>(x => x.Name == TestAttributeName));
        });
    }

    [Test]
    public void Build_With_Valid_Link_And_Label_Attributes_Then_RemoveAttribute_Should_Return_Expected_Link()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithUrl(Url)
            .AndLabel(Label)
            .SetAttribute(TestAttributeName, true)
            .RemoveAttribute(TestAttributeName)
            .Build();

        Assert.That(link, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(link.Attributes, Has.Exactly(1).Matches<HtmlAttribute>(x => x.Name == HrefAttributeName));
            Assert.That(link.Attributes, Has.Exactly(0).Matches<HtmlAttribute>(x => x.Name == TestAttributeName));
        });
    }

}
