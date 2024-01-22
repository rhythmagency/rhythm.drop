namespace Rhythm.Drop.Builders.Tests.Images;

using Rhythm.Drop.Builders.Images;

/// <summary>
/// Tests covering <see cref="DefaultImageBuilder"/> creating simple images with only AltText and Url properties.
/// </summary>
[TestFixture]
public class DefaultImageBuilderWithDimensionsTests : DefaultImageBuilderTestsBase
{
    private const int DefaultImageWidth = 200;
    
    private const int DefaultImageHeight = 200;

    [Test]
    public void Build_With_ImageUrl_And_Dimensions_Should_Return_Image()
    {
        // act
        var builder = new DefaultImageBuilder();

        // arrange
        var image = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .AddDimensions(DefaultImageWidth, DefaultImageHeight)
            .Build();

        // assert
        Assert.That(image, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(image.Url, Is.EqualTo(ImageUrl));
            Assert.That(image.AltText, Is.EqualTo(AltText));
            Assert.That(image.Width, Is.EqualTo(DefaultImageWidth));
            Assert.That(image.Height, Is.EqualTo(DefaultImageHeight));
            Assert.That(image.Sources, Is.Empty);
        });
    }

    [Test]
    public void Build_With_Dimensions_And_No_ImageUrl_Should_Return_Default()
    {
        // act
        var builder = new DefaultImageBuilder();

        // arrange
        var image = builder
            .WithAltText(AltText)
            .AndUrl(NoImageUrl)
            .AddDimensions(DefaultImageWidth, DefaultImageHeight)
            .Build();

        // assert
        Assert.That(image, Is.Default);
    }
}
