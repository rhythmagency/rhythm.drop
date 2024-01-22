namespace Rhythm.Drop.Builders.Tests.Images;

using Rhythm.Drop.Builders.Images;

/// <summary>
/// Tests covering <see cref="DefaultImageBuilder"/> creating simple images with only AltText and Url properties.
/// </summary>
[TestFixture]
public class DefaultImageBuilderSimpleImageTests : DefaultImageBuilderTestsBase
{
    [Test]
    public void Build_With_ImageUrl_And_AltText_Should_Return_Image()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var image = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .Build();

        // assert
        Assert.That(image, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(image.Url, Is.EqualTo(ImageUrl));
            Assert.That(image.AltText, Is.EqualTo(AltText));
            Assert.That(image.Width, Is.Default);
            Assert.That(image.Height, Is.Default);
            Assert.That(image.Sources, Is.Empty);
        });
    }

    [Test]
    public void Build_With_AltText_But_No_ImageUrl_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var image = builder
            .WithAltText(AltText)
            .AndUrl(NoImageUrl)
            .Build();

        // assert
        Assert.That(image, Is.Default);
    }

    [Test]
    public void Build_With_ImageUrl_But_No_AltText_Should_Return_Image()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var image = builder
            .WithAltText(NoAltText)
            .AndUrl(ImageUrl)
            .Build();

        // assert
        Assert.That(image, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(image.Url, Is.EqualTo(ImageUrl));
            Assert.That(image.AltText, Is.EqualTo(NoAltText));
            Assert.That(image.Width, Is.Default);
            Assert.That(image.Height, Is.Default);
            Assert.That(image.Sources, Is.Empty);
        });
    }

    [Test]
    public void Build_With_No_AltText_Or_ImageUrl_Return_Default()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var image = builder
            .WithAltText(NoAltText)
            .AndUrl(NoImageUrl)
            .Build();

        // assert
        Assert.That(image, Is.Default);
    }
}