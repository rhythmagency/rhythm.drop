namespace Rhythm.Drop.Builders.Images;

using Rhythm.Drop.Models.Images;

/// <summary>
/// A contract for creating a fluent builder used to create <see cref="IImage"/>
/// </summary>
public interface IImageBuilder
{
    /// <summary>
    /// Adds alt text to the builder.
    /// </summary>
    /// <param name="altText">The alt text.</param>
    /// <returns>A <see cref="IAltTextImageBuilder"/>.</returns>
    IAltTextImageBuilder WithAltText(string? altText);
}