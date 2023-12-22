namespace Rhythm.Drop.Models.Images;

public interface IImageSource
{
    IReadOnlyImageSourceSet SourceSet { get; }

    string? MimeType { get; }

    IImageSourceMediaQuery? MediaQuery { get; }

    int? Width { get; }

    int? Height { get; }
}