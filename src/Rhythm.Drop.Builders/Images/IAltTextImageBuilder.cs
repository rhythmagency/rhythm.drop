namespace Rhythm.Drop.Builders.Images;

using Rhythm.Drop.Builders.Images.Common;

/// <summary>
/// An image builder with alt text.
/// </summary>
public interface IAltTextImageBuilder : IAndUrlImageBuilder<IUrlAndAltTextImageBuilder>
{
    /// <summary>
    /// Gets the alt text of the builder.
    /// </summary>
    string? AltText { get; }
}