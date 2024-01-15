namespace Rhythm.Drop.Builders.Images;

/// <summary>
/// The default implementation of <see cref="IImageBuilder"/>.
/// </summary>
public sealed class DefaultImageBuilder : IImageBuilder
{
    /// <inheritdoc/>
    public IAltTextImageBuilder WithAltText(string? altText)
    {
        return new AltTextImageBuilder(altText);
    }
}