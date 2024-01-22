namespace Rhythm.Drop.Builders.Tests.Images;

using Rhythm.Drop.Builders.Images;
using Rhythm.Drop.Models.Images;
using Rhythm.Drop.Models.Images.MediaQueries;

[TestFixture]
public class DefaultImageBuilderSourcesTests : DefaultImageBuilderTestsBase
{
    private const string ImageSourceUrl = "/image2.jpg";

    private const string SecondImageSourceUrl = "/image3.jpg";

    private readonly IImageSourceMediaQuery _defaultImageSourceMediaQuery = new MinMaxWidthRangeImageSourceMediaQuery(default, 600);

    [Test]
    public void Build_With_ImageUrl_And_One_Source_Should_Return_Image()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var source = new ImageSource(ImageSourceUrl, _defaultImageSourceMediaQuery);
        var image = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .AddSource(source)
            .Build();

        // assert
        Assert.That(image, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(image.Url, Is.EqualTo(ImageUrl));
            Assert.That(image.AltText, Is.EqualTo(AltText));
            Assert.That(image.Width, Is.Default);
            Assert.That(image.Height, Is.Default);
            Assert.That(image.Sources, Has.Exactly(1).Items);
        });
    }

    [Test]
    public void Build_With_One_Source_And_No_Image_Url_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var source = new ImageSource(ImageSourceUrl, _defaultImageSourceMediaQuery);
        var image = builder
            .WithAltText(AltText)
            .AndUrl(NoImageUrl)
            .AddSource(source)
            .Build();

        // assert
        Assert.That(image, Is.Default);
    }

    [Test]
    public void Build_With_Image_Url_And_Two_AddSource_Should_Return_Image()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var source = new ImageSource(ImageSourceUrl, _defaultImageSourceMediaQuery);
        var source2 = new ImageSource(SecondImageSourceUrl);

        var image = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .AddSource(source)
            .AddSource(source2)
            .Build();

        // assert
        Assert.That(image, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(image.Url, Is.EqualTo(ImageUrl));
            Assert.That(image.AltText, Is.EqualTo(AltText));
            Assert.That(image.Width, Is.Default);
            Assert.That(image.Height, Is.Default);
            Assert.That(image.Sources, Has.Exactly(2).Items);
        });
    }


    [Test]
    public void Build_With_Two_AddSource_And_No_Image_Url_Should_Return_Default()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var source = new ImageSource(ImageSourceUrl, _defaultImageSourceMediaQuery);
        var source2 = new ImageSource(SecondImageSourceUrl);

        var image = builder
            .WithAltText(AltText)
            .AndUrl(NoImageUrl)
            .AddSource(source)
            .AddSource(source2)
            .Build();

        // assert
        Assert.That(image, Is.Default);
    }

    [Test]
    public void Build_With_Image_Url_And_AddSources_Should_Return_Images()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var sources = new List<ImageSource>() {
            new(ImageSourceUrl, _defaultImageSourceMediaQuery),
            new("/image3.jpg")
        };

        var image = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .AddSources(sources)
            .Build();

        // assert
        Assert.That(image, Is.Not.Default);
        Assert.Multiple(() =>
        {
            Assert.That(image.Url, Is.EqualTo(ImageUrl));
            Assert.That(image.AltText, Is.EqualTo(AltText));
            Assert.That(image.Width, Is.Default);
            Assert.That(image.Height, Is.Default);
            Assert.That(image.Sources, Has.Exactly(sources.Count).Items);
        });
    }

    [Test]
    public void Build_With_AddSources_And_No_Image_Url_Should_Return_Images()
    {
        // arrange
        var builder = new DefaultImageBuilder();

        // act
        var sources = new List<ImageSource>() {
            new(ImageSourceUrl, _defaultImageSourceMediaQuery),
            new(SecondImageSourceUrl)
        };

        var image = builder
            .WithAltText(AltText)
            .AndUrl(NoImageUrl)
            .AddSources(sources)
            .Build();

        // assert
        Assert.That(image, Is.Default);
    }



    [Test]
    public void Build_With_AddSources_Or_Two_AddSource_Should_Return_Same_Image()
    {
        // arrange
        var builder = new DefaultImageBuilder();


        // act
        ImageSource source1 = new(ImageSourceUrl, _defaultImageSourceMediaQuery);
        ImageSource source2 = new(SecondImageSourceUrl);

        var sources = new List<ImageSource>() {
            source1,
            source2
        };

        var imageWithMultipleAddSource = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .AddSource(source1)
            .AddSource(source2)
            .Build();

        var imageWithAddSources = builder
            .WithAltText(AltText)
            .AndUrl(ImageUrl)
            .AddSources(sources)
            .Build();


        // assert
        Assert.That(imageWithMultipleAddSource, Is.Not.Default);
        Assert.That(imageWithAddSources, Is.Not.Default);

        Assert.Multiple(() =>
        {
            Assert.That(imageWithMultipleAddSource.Url, Is.EqualTo(imageWithAddSources.Url));
            Assert.That(imageWithMultipleAddSource.AltText, Is.EqualTo(imageWithAddSources.AltText));
            Assert.That(imageWithMultipleAddSource.Width, Is.EqualTo(imageWithAddSources.Width));
            Assert.That(imageWithMultipleAddSource.Height, Is.EqualTo(imageWithAddSources.Height));
            Assert.That(imageWithMultipleAddSource.Sources, Is.EqualTo(imageWithAddSources.Sources));
        });
    }


}
