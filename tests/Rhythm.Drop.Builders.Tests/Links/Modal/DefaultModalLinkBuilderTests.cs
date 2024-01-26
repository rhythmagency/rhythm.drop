namespace Rhythm.Drop.Builders.Tests.Links.Modal;

using Rhythm.Drop.Builders.Links;
using Rhythm.Drop.Models.Components;
using Rhythm.Drop.Models.Modals;

[TestFixture]
public class DefaultModalLinkBuilderTests
{
    private const string Label = "Open";

    private const string? NoLabel = default;

    private static readonly IModal? _noModal = default;

    private static readonly IModal? _modalThatHasNoContent = new Modal("no-content", []);

    private static readonly IModal? _modalThatHasContent = new Modal("content", [new FakeComponent()]);

    [Test]
    public void Build_With_Label_And_No_Modal_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithModal(_noModal)
            .AndLabel(Label)
            .Build();

        // assert
        Assert.That(link, Is.Default);
    }

    [Test]
    public void Build_With_Modal_That_Has_Content_And_No_Label_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithModal(_modalThatHasContent)
            .AndLabel(NoLabel)
            .Build();

        // assert
        Assert.That(link, Is.Default);
    }

    [Test]
    public void Build_With_No_Modal_And_No_Label_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithModal(_noModal)
            .AndLabel(NoLabel)
            .Build();

        // assert
        Assert.That(link, Is.Default);
    }

    [Test]
    public void Build_With_Modal_That_Has_Content_And_Label_Should_Return_Link()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithModal(_modalThatHasContent)
            .AndLabel(Label)
            .Build();

        // assert
        Assert.That(link, Is.Not.Default);
    }

    [Test]
    public void Build_With_Modal_That_Has_No_Content_And_Label_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultLinkBuilder();

        // act
        var link = builder
            .WithModal(_modalThatHasNoContent)
            .AndLabel(Label)
            .Build();

        // assert
        Assert.That(link, Is.Default);
    }

    /// <summary>
    /// A fake component that is used for testing modal links.
    /// </summary>
    private sealed class FakeComponent : IComponent
    {
        public string ViewName => "Fake";
    }
}
